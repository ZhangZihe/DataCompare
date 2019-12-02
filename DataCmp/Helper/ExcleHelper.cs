using LumenWorks.Framework.IO.Csv;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCmp.Helper
{
    public partial class ExcelHelper
    {
        public static HashSet<string> ExtraData(string filePath, int columnIndex, out string error)
        {
            error = null;

            try
            {
                var file = new FileInfo(filePath);
                var transfer = ExcelHelper.TransferSampleFactory.Create(file);
                var data = transfer.GetData(file.OpenRead(), columnIndex);
                return data;
            }
            catch(Exception e)
            {
                error = e.ToString();
                return null;
            }
        }

        public static System.Text.Encoding GetType(string FILE_NAME)
        {
            FileStream fs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read);
            Encoding r = GetType(fs);
            fs.Close();
            return r;
        }

        public static System.Text.Encoding GetType(FileStream fs)
        {
            byte[] Unicode = new byte[] { 0xFF, 0xFE, 0x41 };
            byte[] UnicodeBIG = new byte[] { 0xFE, 0xFF, 0x00 };
            byte[] UTF8 = new byte[] { 0xEF, 0xBB, 0xBF }; //带BOM 
            Encoding reVal = Encoding.Default;

            BinaryReader r = new BinaryReader(fs, System.Text.Encoding.Default);
            int i;
            int.TryParse(fs.Length.ToString(), out i);
            byte[] ss = r.ReadBytes(i);
            if (IsUTF8Bytes(ss) || (ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF))
            {
                reVal = Encoding.UTF8;
            }
            else if (ss[0] == 0xFE && ss[1] == 0xFF && ss[2] == 0x00)
            {
                reVal = Encoding.BigEndianUnicode;
            }
            else if (ss[0] == 0xFF && ss[1] == 0xFE && ss[2] == 0x41)
            {
                reVal = Encoding.Unicode;
            }
            r.Close();
            return reVal;
        }

        private static bool IsUTF8Bytes(byte[] data)
        {
            int charByteCounter = 1; //计算当前正分析的字符应还有的字节数 
            byte curByte; //当前分析的字节. 
            for (int i = 0; i < data.Length; i++)
            {
                curByte = data[i];
                if (charByteCounter == 1)
                {
                    if (curByte >= 0x80)
                    {
                        //判断当前 
                        while (((curByte <<= 1) & 0x80) != 0)
                        {
                            charByteCounter++;
                        }
                        //标记位首位若为非0 则至少以2个1开始 如:110XXXXX...........1111110X 
                        if (charByteCounter == 1 || charByteCounter > 6)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    //若是UTF-8 此时第一位必须为1 
                    if ((curByte & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    charByteCounter--;
                }
            }
            if (charByteCounter > 1)
            {
                throw new Exception("非预期的byte格式");
            }
            return true;
        }
    }

    public partial class ExcelHelper
    {
        /// <summary>
        /// 数据转换
        /// </summary>
        public interface ITransferData
        {
            Stream GetStream(DataTable table);
            
            DataTable GetData(Stream stream);

            HashSet<string> GetData(Stream stream, int cloumnIndex);
        }

        /// <summary>
        /// factory
        /// </summary>
        public class TransferSampleFactory
        {
            public static ITransferData Create(FileInfo fileInfo)
            {
                var ext = fileInfo.Extension;
                if (string.IsNullOrWhiteSpace(ext))
                    throw new Exception("unkown Ext");
                ext = ext.ToLower();
                if (ext == ".csv")
                {
                    return new CsvTransferData(ExcelHelper.GetType(fileInfo.FullName));
                }
                if (ext == ".xls")
                {
                    return new XlsTransferData();
                }
                if (ext == ".xlsx")
                {
                    return new XlsxTransferData();
                }
                return null;
            }
        }

        /// <summary>
        /// csv 仅支持，双引号，逗号分割
        /// </summary>
        public class CsvTransferData : ITransferData
        {
            private Encoding _encode;
            public CsvTransferData(Encoding encode)
            {
                this._encode = encode; //Encoding.GetEncoding("utf-8");
            }

            public Stream GetStream(DataTable table)
            {
                StringBuilder sb = new StringBuilder();
                if (table != null && table.Columns.Count > 0 && table.Rows.Count > 0)
                {
                    foreach (DataRow item in table.Rows)
                    {
                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            if (i > 0)
                            {
                                sb.Append(",");
                            }
                            if (item[i] != null)
                            {
                                sb.Append("\"").Append(item[i].ToString().Replace("\"", "\"\"")).Append("\"");
                            }
                        }
                        sb.Append("\n");
                    }
                }
                MemoryStream stream = new MemoryStream(_encode.GetBytes(sb.ToString()));
                return stream;
            }

            public DataTable GetData(Stream stream)
            {
                using (stream)
                {
                    using (StreamReader input = new StreamReader(stream, _encode))
                    {
                        using (CsvReader csv = new CsvReader(input, true, ',', '"', '"', '#', ValueTrimmingOptions.All))
                        {
                            DataTable dt = new DataTable();

                            string[] heads = csv.GetFieldHeaders();
                            foreach (string item in heads)
                            {
                                DataColumn dc = new DataColumn(item.Trim());
                                dt.Columns.Add(dc);
                            }

                            while (csv.ReadNextRecord())
                            {
                                DataRow dr = dt.NewRow();
                                for (int i = 0; i < csv.FieldCount; i++)
                                {
                                    if (!string.IsNullOrWhiteSpace(csv[i]))
                                    {
                                        dr[i] = csv[i];
                                    }
                                }
                                dt.Rows.Add(dr);
                            }
                            return dt;
                        }

                    }
                }
            }

            public HashSet<string> GetData(Stream stream, int cloumnIndex)
            {
                using (stream)
                {
                    using (StreamReader input = new StreamReader(stream, _encode))
                    {
                        using (CsvReader csv = new CsvReader(input, true, ',', '"', '"', '#', ValueTrimmingOptions.All))
                        {
                            var set = new HashSet<string>();
                            while (csv.ReadNextRecord())
                            {
                                if (cloumnIndex >= 0)
                                {
                                    for (int i = 0; i < csv.FieldCount; i++)
                                    {
                                        if (i == cloumnIndex && !string.IsNullOrWhiteSpace(csv[i]))
                                            set.Add(csv[i]?.Replace("`", ""));
                                    }
                                }
                                else
                                {
                                    var values = new List<string>();
                                    for (int i = 0; i < csv.FieldCount; i++)
                                        values.Add(csv[i]?.Replace("`", ""));
                                    set.Add(string.Join(",", values));
                                }
                            }
                            return set;
                        }

                    }
                }
            }
        }

        /// <summary>
        /// excel
        /// </summary>
        public class ExcelTransferData : ITransferData
        {
            protected IWorkbook _workBook;

            public virtual Stream GetStream(DataTable table)
            {
                var sheet = _workBook.CreateSheet();
                if (table != null)
                {
                    var rowCount = table.Rows.Count;
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        var row = sheet.CreateRow(i);
                        for (int j = 0; j < table.Columns.Count; j++)
                        {
                            var cell = row.CreateCell(j);
                            if (table.Rows[i][j] != null)
                            {
                                cell.SetCellValue(table.Rows[i][j].ToString());
                            }
                        }
                    }
                }
                MemoryStream ms = new MemoryStream();
                _workBook.Write(ms);
                return ms;
            }

            public virtual DataTable GetData(Stream stream)
            {
                using (stream)
                {
                    var sheet = _workBook.GetSheetAt(0);
                    if (sheet != null)
                    {
                        var headerRow = sheet.GetRow(0);
                        DataTable dt = new DataTable();
                        int columnCount = headerRow.Cells.Count;
                        for (int i = 0; i < columnCount; i++)
                        {
                            dt.Columns.Add(headerRow.Cells[i].ToString().Trim());
                        }
                        var row = sheet.GetRowEnumerator();
                        while (row.MoveNext())
                        {
                            var dtRow = dt.NewRow();
                            var excelRow = row.Current as IRow;
                            for (int i = 0; i < columnCount; i++)
                            {
                                var cell = excelRow.GetCell(i);

                                if (cell != null)
                                {
                                    dtRow[i] = GetValue(cell);
                                }
                            }
                            dt.Rows.Add(dtRow);
                        }
                        return dt;
                    }
                }

                return null;
            }

            public virtual HashSet<string> GetData(Stream stream, int cloumnIndex)
            {
                using (stream)
                {
                    var sheet = _workBook.GetSheetAt(0);
                    if (sheet != null)
                    {
                        var set = new HashSet<string>();
                        var row = sheet.GetRowEnumerator();
                        while (row.MoveNext())
                        {
                            var excelRow = row.Current as IRow;
                            if (cloumnIndex >= 0)
                            {
                                if (excelRow.Cells.Count > cloumnIndex && excelRow.GetCell(cloumnIndex) != null)
                                    set.Add(GetValue(excelRow.GetCell(cloumnIndex))?.ToString()?.Replace("`", ""));
                            }
                            else
                            {
                                set.Add(string.Join(",", excelRow.Cells.Select(x => x?.ToString()?.Replace("`", ""))));
                            }
                        }
                        return set;
                    }
                }

                return null;
            }


            private object GetValue(ICell cell)
            {
                object value = null;
                switch (cell.CellType)
                {
                    case CellType.Blank:
                        break;
                    case CellType.Boolean:
                        value = cell.BooleanCellValue ? "1" : "0"; break;
                    case CellType.Error:
                        value = cell.ErrorCellValue; break;
                    case CellType.Formula:
                        value = "=" + cell.CellFormula; break;
                    case CellType.Numeric:
                        value = cell.NumericCellValue.ToString(); break;
                    case CellType.String:
                        value = cell.StringCellValue; break;
                    case CellType.Unknown:
                        break;
                }
                return value;
            }
        }

        /// <summary>
        /// office 97~2003
        /// </summary>
        public class XlsTransferData : ExcelTransferData
        {
            public override Stream GetStream(DataTable table)
            {
                base._workBook = new HSSFWorkbook();
                return base.GetStream(table);
                return base.GetStream(table);
            }

            public override DataTable GetData(Stream stream)
            {
                base._workBook = new HSSFWorkbook(stream);
                return base.GetData(stream);
            }

            public override HashSet<string> GetData(Stream stream, int cloumnIndex)
            {
                base._workBook = new HSSFWorkbook(stream);
                return base.GetData(stream, cloumnIndex);
            }
        }

        /// <summary>
        /// office 2007
        /// </summary>
        public class XlsxTransferData : ExcelTransferData
        {

            public override Stream GetStream(DataTable table)
            {
                base._workBook = new XSSFWorkbook();
                return base.GetStream(table);
            }

            public override DataTable GetData(Stream stream)
            {
                base._workBook = new XSSFWorkbook(stream);
                return base.GetData(stream);
            }

            public override HashSet<string> GetData(Stream stream, int cloumnIndex)
            {
                base._workBook = new XSSFWorkbook(stream);
                return base.GetData(stream, cloumnIndex);
            }
        }
    }
}
