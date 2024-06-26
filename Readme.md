<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128550826/19.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T576892)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Grid View for ASP.NET MVC - How to display data from an uploaded Excel file

This example demonstrates how to use the [UploadControl](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.UploadControlExtension) to allow users to upload a Microsoft Excel file to the server and view the uploaded file's data in the grid.

> **Note:** The example application uses the `DevExpress.Docs` assembly. The [Document Server](https://www.devexpress.com/Products/NET/Document-Server/) subscription license is required to use the demonstrated technique.

## Overview

1. Implement the *Helper* class that returns the *DataTable* object based on your Excel file.

2. Implement the *HomeControllerUploadControlSettings* class. In this class, do the following:

   * Create the `FileUploadComplete` event that saves the uploaded file and its path.
   * Specify the *UploadValidationSettings* property that returns the upload control's validation settings.

    ```cs
    public static void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e) {
        if (e.UploadedFile.IsValid) {
            resultFilePath = HttpContext.Current.Request.MapPath(UploadDirectory + e.UploadedFile.FileName);
            e.UploadedFile.SaveAs(resultFilePath, true);
            IUrlResolutionService urlResolver = sender as IUrlResolutionService;
            if (urlResolver != null) {
                e.CallbackData = urlResolver.ResolveClientUrl(resultFilePath);
            }
        }
    }
    ```

3. Map the upload control's `CallbackRouteValues` property to the `UploadControlUpload` action. In this action, call the control's [GetUploadedFiles](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.UploadControlExtension.GetUploadedFiles(DevExpress.Web.Mvc.UploadControlSettings-System.EventHandler-DevExpress.Web.FileUploadCompleteEventArgs-)) method to pass validation settings and call the `FileUploadComplete` method.

    ```cs
    public ActionResult UploadControlUpload() {
        UploadControlExtension.GetUploadedFiles("UploadControl", HomeControllerUploadControlSettings.UploadValidationSettings, HomeControllerUploadControlSettings.FileUploadComplete);
        return null;
    }
    ```

4. In the `GridViewPartial` action, use the *Helper* class to get the *DataTable* object and pass this table as a model to the Partial View.

    ```cs
    public ActionResult GridViewPartial() {
        var model = string.IsNullOrEmpty(HomeControllerUploadControlSettings.resultFilePath) ? null : helperClass.GetTableFromExcel();
        return PartialView("_GridViewPartial", model);
    }
    ```

## Files to Review

* [HomeController.cs](./CS/UploadControlApplication/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/UploadControlApplication/Controllers/HomeController.vb))
* [HelperClass.cs](./CS/UploadControlApplication/Models/HelperClass.cs) (VB: [HelperClass.vb](./VB/UploadControlApplication/Models/HelperClass.vb))
* [_GridViewPartial.cshtml](./CS/UploadControlApplication/Views/Home/_GridViewPartial.cshtml)
* [Index.cshtml](./CS/UploadControlApplication/Views/Home/Index.cshtml)

## More Examples

* [Grid View for ASP.NET Web Forms - How to display data from an uploaded Excel file](https://github.com/DevExpress-Examples/aspxgridview-upload-and-display-excel-file)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-mvc-grid-upload-and-display-excel-file&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-mvc-grid-upload-and-display-excel-file&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
