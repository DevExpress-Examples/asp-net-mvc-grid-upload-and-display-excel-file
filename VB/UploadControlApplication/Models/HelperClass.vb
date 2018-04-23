Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports DevExpress.Spreadsheet
Imports System.IO
Imports DevExpress.Spreadsheet.Export
Imports System.Data
Imports UploadControlApplication.Controllers

Namespace UploadControlApplication.Models
	Public Class HelperClass

		Public Function GetTableFromExcel() As DataTable
			Dim book As New Workbook()
			book.LoadDocument(HomeControllerUploadControlSettings.resultFilePath)
			Dim sheet As Worksheet = book.Worksheets.ActiveWorksheet
			Dim range As Range = sheet.GetUsedRange()
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
End Namespace