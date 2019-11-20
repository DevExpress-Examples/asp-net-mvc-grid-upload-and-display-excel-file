@Code
    ViewData("Title") = "Home Page"
End Code

@ModelType System.Collections.IEnumerable

<script type="text/javascript">
    function OnFileUploadComplete(s, e) {
        if (e.callbackData !== "") {
            GridView.PerformCallback();
        }
        else {
            alert("The selected file was not uploaded.");
        }
    }
</script>


@Using (Html.BeginForm("UploadControlUpload", "Home", FormMethod.Post))
    @Html.DevExpress().UploadControl(Sub(settings)
                                          settings.Name = "UploadControl"
                                          settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "UploadControlUpload"}

                                          settings.ClientSideEvents.FileUploadComplete = "OnFileUploadComplete"
                                          settings.ShowUploadButton = True
                                          settings.ShowProgressPanel = True

                                          settings.ValidationSettings.Assign(UploadControlApplication.HomeControllerUploadControlSettings.UploadValidationSettings)
                                      End Sub).GetHtml()
End Using
@Html.Partial("_GridViewPartial", Model)