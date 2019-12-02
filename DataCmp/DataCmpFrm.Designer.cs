namespace DataCmp
{
    partial class DataCmpFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataCmpFrm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textLeftInfo = new System.Windows.Forms.TextBox();
            this.textRightInfo = new System.Windows.Forms.TextBox();
            this.textLeft = new System.Windows.Forms.TextBox();
            this.textRight = new System.Windows.Forms.TextBox();
            this.textLeftResult = new System.Windows.Forms.TextBox();
            this.textRightResult = new System.Windows.Forms.TextBox();
            this.ckbOnlyTopCol = new System.Windows.Forms.CheckBox();
            this.btnCmp = new System.Windows.Forms.Button();
            this.proCmpRtL = new System.Windows.Forms.ProgressBar();
            this.proCmpLtR = new System.Windows.Forms.ProgressBar();
            this.btnCmpRtL = new System.Windows.Forms.Button();
            this.btnCmpLtR = new System.Windows.Forms.Button();
            this.rdoText = new System.Windows.Forms.RadioButton();
            this.rdoFile = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFileLeft = new System.Windows.Forms.Button();
            this.textFileLeft = new System.Windows.Forms.TextBox();
            this.cbbRight = new System.Windows.Forms.ComboBox();
            this.textFileRight = new System.Windows.Forms.TextBox();
            this.cbbLeft = new System.Windows.Forms.ComboBox();
            this.btnFileRight = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.textLeftInfo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textRightInfo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textLeft, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textRight, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textLeftResult, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textRightResult, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 430);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textLeftInfo
            // 
            this.textLeftInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textLeftInfo.Location = new System.Drawing.Point(3, 407);
            this.textLeftInfo.Name = "textLeftInfo";
            this.textLeftInfo.ReadOnly = true;
            this.textLeftInfo.Size = new System.Drawing.Size(374, 21);
            this.textLeftInfo.TabIndex = 5;
            // 
            // textRightInfo
            // 
            this.textRightInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textRightInfo.Location = new System.Drawing.Point(383, 407);
            this.textRightInfo.Name = "textRightInfo";
            this.textRightInfo.ReadOnly = true;
            this.textRightInfo.Size = new System.Drawing.Size(374, 21);
            this.textRightInfo.TabIndex = 6;
            // 
            // textLeft
            // 
            this.textLeft.AcceptsReturn = true;
            this.textLeft.AcceptsTab = true;
            this.textLeft.AllowDrop = true;
            this.textLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textLeft.Location = new System.Drawing.Point(3, 3);
            this.textLeft.MaxLength = 2147483647;
            this.textLeft.Multiline = true;
            this.textLeft.Name = "textLeft";
            this.textLeft.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textLeft.Size = new System.Drawing.Size(374, 196);
            this.textLeft.TabIndex = 0;
            this.textLeft.Text = "示例数据:\r\n123456\r\n123456789\r\n987156456\r\n489687891251\r\n45789787\r\n";
            // 
            // textRight
            // 
            this.textRight.AcceptsReturn = true;
            this.textRight.AcceptsTab = true;
            this.textRight.AllowDrop = true;
            this.textRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textRight.Location = new System.Drawing.Point(383, 3);
            this.textRight.MaxLength = 2147483647;
            this.textRight.Multiline = true;
            this.textRight.Name = "textRight";
            this.textRight.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textRight.Size = new System.Drawing.Size(374, 196);
            this.textRight.TabIndex = 1;
            this.textRight.Text = "示例数据:\r\n123456\r\n12345678\r\n987156456\r\n48968789125\r\n45789787";
            // 
            // textLeftResult
            // 
            this.textLeftResult.AcceptsReturn = true;
            this.textLeftResult.AcceptsTab = true;
            this.textLeftResult.AllowDrop = true;
            this.textLeftResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textLeftResult.Location = new System.Drawing.Point(3, 205);
            this.textLeftResult.MaxLength = 2147483647;
            this.textLeftResult.Multiline = true;
            this.textLeftResult.Name = "textLeftResult";
            this.textLeftResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textLeftResult.Size = new System.Drawing.Size(374, 196);
            this.textLeftResult.TabIndex = 2;
            // 
            // textRightResult
            // 
            this.textRightResult.AcceptsReturn = true;
            this.textRightResult.AcceptsTab = true;
            this.textRightResult.AllowDrop = true;
            this.textRightResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textRightResult.Location = new System.Drawing.Point(383, 205);
            this.textRightResult.MaxLength = 2147483647;
            this.textRightResult.Multiline = true;
            this.textRightResult.Name = "textRightResult";
            this.textRightResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textRightResult.Size = new System.Drawing.Size(374, 196);
            this.textRightResult.TabIndex = 3;
            // 
            // ckbOnlyTopCol
            // 
            this.ckbOnlyTopCol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbOnlyTopCol.AutoSize = true;
            this.ckbOnlyTopCol.Location = new System.Drawing.Point(5, 475);
            this.ckbOnlyTopCol.Name = "ckbOnlyTopCol";
            this.ckbOnlyTopCol.Size = new System.Drawing.Size(84, 16);
            this.ckbOnlyTopCol.TabIndex = 11;
            this.ckbOnlyTopCol.Text = "仅首列对比";
            this.ckbOnlyTopCol.UseVisualStyleBackColor = true;
            // 
            // btnCmp
            // 
            this.btnCmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCmp.Location = new System.Drawing.Point(712, 470);
            this.btnCmp.Name = "btnCmp";
            this.btnCmp.Size = new System.Drawing.Size(48, 25);
            this.btnCmp.TabIndex = 16;
            this.btnCmp.Text = "对比";
            this.btnCmp.UseVisualStyleBackColor = true;
            this.btnCmp.Click += new System.EventHandler(this.btnCmp_Click);
            // 
            // proCmpRtL
            // 
            this.proCmpRtL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.proCmpRtL.Location = new System.Drawing.Point(604, 471);
            this.proCmpRtL.Name = "proCmpRtL";
            this.proCmpRtL.Size = new System.Drawing.Size(100, 23);
            this.proCmpRtL.TabIndex = 15;
            // 
            // proCmpLtR
            // 
            this.proCmpLtR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.proCmpLtR.Location = new System.Drawing.Point(415, 471);
            this.proCmpLtR.Name = "proCmpLtR";
            this.proCmpLtR.Size = new System.Drawing.Size(100, 23);
            this.proCmpLtR.TabIndex = 13;
            // 
            // btnCmpRtL
            // 
            this.btnCmpRtL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCmpRtL.Location = new System.Drawing.Point(523, 470);
            this.btnCmpRtL.Name = "btnCmpRtL";
            this.btnCmpRtL.Size = new System.Drawing.Size(75, 25);
            this.btnCmpRtL.TabIndex = 14;
            this.btnCmpRtL.Text = "右左对比";
            this.btnCmpRtL.UseVisualStyleBackColor = true;
            this.btnCmpRtL.Click += new System.EventHandler(this.btnCmpRtL_Click);
            // 
            // btnCmpLtR
            // 
            this.btnCmpLtR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCmpLtR.Location = new System.Drawing.Point(334, 470);
            this.btnCmpLtR.Name = "btnCmpLtR";
            this.btnCmpLtR.Size = new System.Drawing.Size(75, 25);
            this.btnCmpLtR.TabIndex = 12;
            this.btnCmpLtR.Text = "左右对比";
            this.btnCmpLtR.UseVisualStyleBackColor = true;
            this.btnCmpLtR.Click += new System.EventHandler(this.btnCmpLtR_Click);
            // 
            // rdoText
            // 
            this.rdoText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoText.AutoSize = true;
            this.rdoText.Checked = true;
            this.rdoText.Location = new System.Drawing.Point(95, 475);
            this.rdoText.Name = "rdoText";
            this.rdoText.Size = new System.Drawing.Size(71, 16);
            this.rdoText.TabIndex = 17;
            this.rdoText.TabStop = true;
            this.rdoText.Text = "对比文本";
            this.rdoText.UseVisualStyleBackColor = true;
            // 
            // rdoFile
            // 
            this.rdoFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoFile.AutoSize = true;
            this.rdoFile.Location = new System.Drawing.Point(172, 475);
            this.rdoFile.Name = "rdoFile";
            this.rdoFile.Size = new System.Drawing.Size(71, 16);
            this.rdoFile.TabIndex = 18;
            this.rdoFile.Text = "对比文件";
            this.rdoFile.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Controls.Add(this.btnFileLeft, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.textFileLeft, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbbRight, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.textFileRight, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbbLeft, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnFileRight, 5, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 435);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(760, 28);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // btnFileLeft
            // 
            this.btnFileLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFileLeft.Location = new System.Drawing.Point(303, 3);
            this.btnFileLeft.Name = "btnFileLeft";
            this.btnFileLeft.Size = new System.Drawing.Size(74, 22);
            this.btnFileLeft.TabIndex = 25;
            this.btnFileLeft.Text = "选择文件";
            this.btnFileLeft.UseVisualStyleBackColor = true;
            this.btnFileLeft.Click += new System.EventHandler(this.btnFileLeft_Click);
            // 
            // textFileLeft
            // 
            this.textFileLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFileLeft.Location = new System.Drawing.Point(3, 3);
            this.textFileLeft.Name = "textFileLeft";
            this.textFileLeft.Size = new System.Drawing.Size(214, 21);
            this.textFileLeft.TabIndex = 8;
            // 
            // cbbRight
            // 
            this.cbbRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbRight.FormattingEnabled = true;
            this.cbbRight.Items.AddRange(new object[] {
            "整行对比",
            "列A",
            "列B",
            "列C",
            "列D",
            "列E",
            "列F",
            "列G",
            "列H",
            "列I",
            "列J",
            "列K",
            "列L",
            "列M",
            "列N",
            "列O",
            "列P",
            "列Q",
            "列R",
            "列S",
            "列T",
            "列U",
            "列V",
            "列W",
            "列X",
            "列Y",
            "列Z"});
            this.cbbRight.Location = new System.Drawing.Point(603, 3);
            this.cbbRight.Name = "cbbRight";
            this.cbbRight.Size = new System.Drawing.Size(74, 20);
            this.cbbRight.TabIndex = 23;
            // 
            // textFileRight
            // 
            this.textFileRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFileRight.Location = new System.Drawing.Point(383, 3);
            this.textFileRight.Name = "textFileRight";
            this.textFileRight.Size = new System.Drawing.Size(214, 21);
            this.textFileRight.TabIndex = 22;
            // 
            // cbbLeft
            // 
            this.cbbLeft.FormattingEnabled = true;
            this.cbbLeft.Items.AddRange(new object[] {
            "整行对比",
            "列A",
            "列B",
            "列C",
            "列D",
            "列E",
            "列F",
            "列G",
            "列H",
            "列I",
            "列J",
            "列K",
            "列L",
            "列M",
            "列N",
            "列O",
            "列P",
            "列Q",
            "列R",
            "列S",
            "列T",
            "列U",
            "列V",
            "列W",
            "列X",
            "列Y",
            "列Z"});
            this.cbbLeft.Location = new System.Drawing.Point(223, 3);
            this.cbbLeft.Name = "cbbLeft";
            this.cbbLeft.Size = new System.Drawing.Size(74, 20);
            this.cbbLeft.TabIndex = 24;
            // 
            // btnFileRight
            // 
            this.btnFileRight.Location = new System.Drawing.Point(683, 3);
            this.btnFileRight.Name = "btnFileRight";
            this.btnFileRight.Size = new System.Drawing.Size(74, 22);
            this.btnFileRight.TabIndex = 26;
            this.btnFileRight.Text = "选择文件";
            this.btnFileRight.UseVisualStyleBackColor = true;
            this.btnFileRight.Click += new System.EventHandler(this.btnFileRight_Click);
            // 
            // DataCmpFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 501);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.rdoFile);
            this.Controls.Add(this.rdoText);
            this.Controls.Add(this.btnCmpLtR);
            this.Controls.Add(this.btnCmpRtL);
            this.Controls.Add(this.proCmpLtR);
            this.Controls.Add(this.proCmpRtL);
            this.Controls.Add(this.btnCmp);
            this.Controls.Add(this.ckbOnlyTopCol);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(780, 540);
            this.Name = "DataCmpFrm";
            this.Text = "数据对比-v1.0";
            this.Load += new System.EventHandler(this.DataCmpFrm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textLeftInfo;
        private System.Windows.Forms.TextBox textRightInfo;
        private System.Windows.Forms.CheckBox ckbOnlyTopCol;
        private System.Windows.Forms.Button btnCmp;
        private System.Windows.Forms.ProgressBar proCmpRtL;
        private System.Windows.Forms.ProgressBar proCmpLtR;
        private System.Windows.Forms.Button btnCmpRtL;
        private System.Windows.Forms.Button btnCmpLtR;
        private System.Windows.Forms.TextBox textLeft;
        private System.Windows.Forms.TextBox textRight;
        private System.Windows.Forms.TextBox textLeftResult;
        private System.Windows.Forms.TextBox textRightResult;
        private System.Windows.Forms.RadioButton rdoText;
        private System.Windows.Forms.RadioButton rdoFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textFileRight;
        private System.Windows.Forms.TextBox textFileLeft;
        private System.Windows.Forms.ComboBox cbbRight;
        private System.Windows.Forms.Button btnFileLeft;
        private System.Windows.Forms.ComboBox cbbLeft;
        private System.Windows.Forms.Button btnFileRight;
    }
}

