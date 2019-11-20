using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using System.Data;
using UploadControlApplication.Controllers;

namespace UploadControlApplication.Models
{
    public class HelperClass
    {
        public DataTable GetTableFromExcel()
        {
            Workbook book = new Workbook();
            book.LoadDocument(HomeControllerUploadControlSettings.resultFilePath);
            Worksheet sheet = book.Worksheets.ActiveWorksheet;
            CellRange range = sheet.GetUsedRange();
            DataTable table = sheet.CreateDataTable(range, false);
            DataTableExporter exporter = sheet.CreateDataTableExporter(range, table, false);
            exporter.CellValueConversionError += exporter_CellValueConversionError;
            exporter.Export();
            return table;
        }

        void exporter_CellValueConversionError(object sender, CellValueConversionErrorEventArgs e)
        {
            e.Action = DataTableExporterAction.Continue;
            e.DataTableValue = null;
        }
    }
}