using DataCmp.Helper;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCmp
{
    public partial class DataCmpFrm : Form
    {
        public DataCmpFrm()
        {
            InitializeComponent();
        }

        private void DataCmpFrm_Load(object sender, EventArgs e)
        {
            EventHandler checkedChanged = (s, args) =>
            {
                textLeft.Enabled = rdoText.Checked;
                textRight.Enabled = rdoText.Checked;
                textFileLeft.Enabled = !rdoText.Checked;
                textFileRight.Enabled = !rdoText.Checked;
                cbbLeft.Enabled = !rdoText.Checked; ;
                cbbRight.Enabled = !rdoText.Checked; ;
                btnFileLeft.Enabled = !rdoText.Checked;
                btnFileRight.Enabled = !rdoText.Checked;
                ckbOnlyTopCol.Enabled = rdoText.Checked;
            };
            rdoText.CheckedChanged += checkedChanged;
            rdoFile.CheckedChanged += checkedChanged;
            checkedChanged.Invoke(null, null);

            cbbLeft.SelectedIndex = 0;
            cbbRight.SelectedIndex = 0;
        }

        private char[] SPLITCHAR = new char[] { ' ', '\t', '|', ',', '\\', '/' };
        private HashSet<string> LstLeft;
        private HashSet<string> LstRight;
        private Thread T1;
        private Thread T2;

        private void LoadData()
        {
            if (rdoText.Checked)
            {
                LstLeft = GetTextBoxList(textLeft);
                LstRight = GetTextBoxList(textRight);
                return;
            }

            if (string.IsNullOrWhiteSpace(textFileLeft.Text) || !File.Exists(textFileLeft.Text))
            {
                textLeftInfo.Text = "请选择您要对比的文件或文件不存在";
                return;
            }

            if (string.IsNullOrWhiteSpace(textFileRight.Text) || !File.Exists(textFileRight.Text))
            {
                textRightInfo.Text = "请选择您要对比的文件或文件不存在";
                return;
            }

            LstLeft = ExcelHelper.ExtraData(textFileLeft.Text, cbbLeft.SelectedIndex - 1, out string leftError);
            LstRight = ExcelHelper.ExtraData(textFileRight.Text, cbbRight.SelectedIndex - 1, out string rightError);

            textLeftInfo.Text = leftError;
            textRightInfo.Text = rightError;
        }

        private HashSet<string> GetTextBoxList(TextBox textBox)
        {
            IEnumerable<string> list = textBox.Text.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            if (ckbOnlyTopCol.Checked)
                list = list.Select(x =>
                {
                    var item = x.Split(SPLITCHAR, StringSplitOptions.RemoveEmptyEntries);
                    return item.Length > 0 ? item[0] : "";
                });

            //转存到HashSet可以提升对比效率
            HashSet<string> hs = new HashSet<string>();
            foreach (var item in list)
                hs.Add(item.Trim()?.Replace("`", ""));

            return hs;
        }

        private int CompareList(HashSet<string> left, HashSet<string> right, TextBox outResult, ProgressBar probar)
        {
            if (left == null || right == null)
                return 0;

            int totalCount = left.Count;
            int dealCount = 0;
            int diffCount = 0;
            StringBuilder result = new StringBuilder();
            Invoke(new Action(() => probar.Maximum = totalCount));

            foreach (string item in left)
            {
                if (!right.Contains(item))
                {
                    result.Append(item + "\r\n");
                    diffCount++;
                }

                if (totalCount > 100 && ++dealCount % 10 == 0)
                {
                    //如果数据超出100, 则每隔10次刷新UI进度条
                    Invoke(new Action(() => probar.Value = dealCount));
                }
            }
            Invoke(new Action(() =>
            {
                probar.Value = totalCount;
                outResult.Text += result;
            }));
            return diffCount;
        }

        private void CompareLeftToRight()
        {
            int count = CompareList(LstLeft, LstRight, textLeftResult, proCmpLtR);
            Invoke(new Action(() =>
            {
                if (LstLeft?.Count > 0)
                    textLeftInfo.Text = string.Concat("共", LstLeft.Count, "项, ", count, "项不同!");
                btnCmpLtR.Enabled = true;
                btnCmp.Enabled = btnCmpLtR.Enabled && btnCmpRtL.Enabled;
            }));
        }

        private void CompareRightToLeft()
        {
            int count = CompareList(LstRight, LstLeft, textRightResult, proCmpRtL);
            Invoke(new Action(() =>
            {
                if (LstRight?.Count > 0)
                    textRightInfo.Text = string.Concat("共", LstRight.Count, "项, ", count, "项不同!");
                btnCmpRtL.Enabled = true;
                btnCmp.Enabled = btnCmpLtR.Enabled && btnCmpRtL.Enabled;
            }));
        }

        private void btnCmp_Click(object sender, EventArgs e)
        {
            btnCmp.Enabled = false;
            btnCmpLtR_Click(null, null);
            btnCmpRtL_Click(null, null);
        }

        private void btnCmpRtL_Click(object sender, EventArgs e)
        {
            btnCmpRtL.Enabled = false;
            btnCmp.Enabled = false;
            proCmpRtL.Value = 0;
            textRightResult.Clear();
            textRightInfo.Clear();
            LoadData();

            T2 = new Thread(CompareRightToLeft);
            T2.Start();
        }

        private void btnCmpLtR_Click(object sender, EventArgs e)
        {
            btnCmpLtR.Enabled = false;
            btnCmp.Enabled = false;
            proCmpLtR.Value = 0;
            textLeftResult.Clear();
            textLeftInfo.Clear();
            LoadData();

            T1 = new Thread(CompareLeftToRight);
            T1.Start();
        }

        private void btnFileLeft_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C://";
            dialog.Filter = "表格文件|*.csv;*.xls;*.xlsx;*.txt";
            dialog.RestoreDirectory = false;

            if (dialog.ShowDialog() == DialogResult.OK)
                textFileLeft.Text = dialog.FileName;
        }

        private void btnFileRight_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C://";
            dialog.Filter = "表格文件|*.csv;*.xls;*.xlsx;*.txt";
            dialog.RestoreDirectory = false;

            if (dialog.ShowDialog() == DialogResult.OK)
                textFileRight.Text = dialog.FileName;
        }
    }
}
