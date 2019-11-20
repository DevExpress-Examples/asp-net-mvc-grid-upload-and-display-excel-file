Imports DevExpress.Web.Mvc

Public Class HomeController
        Inherits System.Web.Mvc.Controller

        Function Index() As ActionResult
            Return View()
        End Function

        Private helperClass As New HelperClass()

        Public Function UploadControlUpload() As ActionResult
            UploadControlExtension.GetUploadedFiles("UploadControl", HomeControllerUploadControlSettings.UploadValidationSettings, AddressOf HomeControllerUploadControlSettings.FileUploadComplete)
            Return Nothing
        End Function

        Public Function GridViewPartial() As ActionResult
            Dim model = If(String.IsNullOrEmpty(HomeControllerUploadControlSettings.resultFilePath), Nothing, helperClass.GetTableFromExcel())
            Return PartialView("_GridViewPartial", model)
        End Function
    End Class

    Public Class HomeControllerUploadControlSettings
        Public Const UploadDirectory As String = "~/UploadFolder/"
        Public Shared UploadValidationSettings As New DevExpress.Web.UploadControlValidationSettings() With {
            .AllowedFileExtensions = New String() {".xls", ".xlsx"},
            .MaxFileSize = 4000000
        }
        Public Shared resultFilePath As String = String.Empty
        Public Shared Sub FileUploadComplete(ByVal sender As Object, ByVal e As DevExpress.Web.FileUploadCompleteEventArgs)
            If e.UploadedFile.IsValid Then
                resultFilePath = HttpContext.Current.Request.MapPath(UploadDirectory & e.UploadedFile.FileName)
                e.UploadedFile.SaveAs(resultFilePath, True)
                Dim urlResolver As IUrlResolutionService = TryCast(sender, IUrlResolutionService)
                If urlResolver IsNot Nothing Then
                    e.CallbackData = urlResolver.ResolveClientUrl(resultFilePath)
                End If

            End If
        End Sub
End Class