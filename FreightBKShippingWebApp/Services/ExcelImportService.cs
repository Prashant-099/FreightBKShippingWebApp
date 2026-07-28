using FreightBKShippingWebApp.Model;
using OfficeOpenXml;

namespace FreightBKShippingWebApp.Services
{
    public class ExcelImportService
    {
        public ExcelColumnMap ReadHeader(ExcelWorksheet ws)
        {
            ExcelColumnMap map = new();

            for (int c = 1; c <= ws.Dimension.End.Column; c++)
            {
                string h = ws.Cells[1, c].Text.Trim();

                if (!string.IsNullOrWhiteSpace(h))
                    map.Columns[h] = c;
            }

            return map;
        }

        public bool IsBlankRow(ExcelWorksheet ws, int row)
        {
            for (int c = 1; c <= ws.Dimension.End.Column; c++)
            {
                if (!string.IsNullOrWhiteSpace(ws.Cells[row, c].Text))
                    return false;
            }

            return true;
        }

        public string GetText(ExcelWorksheet ws, ExcelColumnMap map, int row, string column)
        {
            if (!map.Has(column))
                return "";

            return ws.Cells[row, map[column]].Text.Trim();
        }

        public DateTime? GetDate(ExcelWorksheet ws, ExcelColumnMap map, int row, string column)
        {
            if (!map.Has(column))
                return null;

            DateTime d;

            if (DateTime.TryParse(ws.Cells[row, map[column]].Text, out d))
                return d;

            return null;
        }
        public double? GetDouble(
    ExcelWorksheet ws,
    ExcelColumnMap map,
    int row,
    string column)
        {
            var text = GetText(ws, map, row, column);

            if (double.TryParse(text, out double value))
                return value;

            return null;
        }
    }
}
