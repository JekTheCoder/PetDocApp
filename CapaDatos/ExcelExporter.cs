using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    using Excel = Microsoft.Office.Interop.Excel;

    public class ExcelExporter
    {
        public void Export(DataTable data, string path)
        {
            var excelApp = new Excel.Application();
            Excel.Workbook book;
            try
            {
                book = excelApp.Workbooks.Open(path);
            }
            catch
            {
                book = excelApp.Workbooks.Add();
            }
            var sheet = (Excel.Worksheet)book.Sheets[1];
            sheet.Cells.Clear();

            SetHeaders(data.Columns, ref sheet);
            SetRows(data.Rows, ref sheet);
            MakeTable(ref data, ref sheet);

            //Save the excel file
            book.SaveAs(path);
            book.Close();
        }

        private static string RangeSelector(int row, int columnStart, int columnEnd)
        {
            return string.Concat(ColumnAdress(columnStart + 1), row.ToString(), ":", ColumnAdress(columnEnd), row.ToString());
        }

        private static void MakeTable(ref DataTable table, ref Excel.Worksheet sheet)
        {
            var rows = table.Rows.Count;
            var columns = table.Columns.Count;
            var selector = string.Concat(ColumnAdress(1), 1.ToString(), ":", ColumnAdress(columns), (rows + 1).ToString());

            var range = sheet.Range[selector];
            sheet.ListObjects.AddEx(Excel.XlListObjectSourceType.xlSrcRange, range, XlListObjectHasHeaders: Excel.XlYesNoGuess.xlYes);
        }

        private static int ColumnMaxLength(ref DataTable table, int column)
        {
            int len = table.Columns[column].ColumnName.Length;
            foreach (DataRow row in table.Rows)
            {
                int localLen = row.ItemArray[column].ToString().Length;
                if (localLen > len) len = localLen;
            }

            return len;
        }

        private static void SetRows(DataRowCollection rows, ref Excel.Worksheet sheet)
        {
            int i = 2;
            foreach (DataRow row in rows)
            {
                WriteRow(row, ref sheet, i);
                i++;
            }
        }

        private static void WriteRow(DataRow row, ref Excel.Worksheet sheet, int i)
        {
            Excel.Range range = sheet.Range[RangeSelector(i, 0, row.ItemArray.Length)];
            List<string> value = new List<string>();
            foreach (var cell in row.ItemArray) value.Add(cell.ToString());

            range.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, value.ToArray());
        }

        private static void SetHeaders(DataColumnCollection columns, ref Excel.Worksheet sheet)
        {
            Excel.Range range = sheet.Range[RangeSelector(1, 0, columns.Count)];
            List<string> value = new List<string>();
            foreach (DataColumn col in columns) value.Add(col.ColumnName);

            range.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, value.ToArray());
        }

        public static string ColumnAdress(int col)
        {
            if (col <= 26)
            {
                return Convert.ToChar(col + 64).ToString();
            }
            int div = col / 26;
            int mod = col % 26;
            if (mod == 0) { mod = 26; div--; }
            return ColumnAdress(div) + ColumnAdress(mod);
        }

        public static int ColumnNumber(string colAdress)
        {
            int[] digits = new int[colAdress.Length];
            for (int i = 0; i < colAdress.Length; ++i)
            {
                digits[i] = Convert.ToInt32(colAdress[i]) - 64;
            }
            int mul = 1; int res = 0;
            for (int pos = digits.Length - 1; pos >= 0; --pos)
            {
                res += digits[pos] * mul;
                mul *= 26;
            }
            return res;
        }
    }
}
