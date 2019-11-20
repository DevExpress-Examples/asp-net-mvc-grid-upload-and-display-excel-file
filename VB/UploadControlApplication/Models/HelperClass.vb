Imports DevExpress.Spreadsheet
Imports DevExpress.Spreadsheet.Export
Imports UploadControlApplication.UploadControlApplication.Controllers

Public Class HelperClass
    Public Function GetTableFromExcel() As DataTable
        Dim book As New Workbook()
        book.LoadDocument(HomeControllerUploadControlSettings.resultFilePath)
        Dim sheet As Worksheet = book.Worksheets.ActiveWorksheet
        Dim range As CellRange = sheet.GetUsedRange()
        Dim table As DataTable = sheet.CreateDataTable(range, False)
        Dim exporter As DataTableExporter = sheet.CreateDataTableExporter(range, table, False)
        AddHandler exporter.CellValueConversionError, AddressOf exporter_CellValueConversionError
        exporter.Export()
        Return table
    End Function

    Private Sub exporter_CellValueConversionError(ByVal sender As Object, ByVal e As CellValueConversionErrorEventArgs)
        e.Action = DataTableExporterAction.Continue
        e.DataTableValue = Nothing
    End Sub
End Class
