<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128550826/17.1.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T576892)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/UploadControlApplication/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/UploadControlApplication/Controllers/HomeController.vb))
* [HelperClass.cs](./CS/UploadControlApplication/Models/HelperClass.cs) (VB: [HelperClass.vb](./VB/UploadControlApplication/Models/HelperClass.vb))
* [_GridViewPartial.cshtml](./CS/UploadControlApplication/Views/Home/_GridViewPartial.cshtml)
* [Index.cshtml](./CS/UploadControlApplication/Views/Home/Index.cshtml)
<!-- default file list end -->
# GridView - How to upload an Excel file via UploadControl and show its data in a grid


<p>This example shows how to load an Excel file from your computer to the server using <strong>MVCxUploadControl</strong> and then display its data in <strong>MVCxGridView</strong>. <br>Steps to implement this task are the following:<br>1. Implement the Helper class that returns the DataTable object based on your Excel file.<br>2. Implement the HomeControllerUploadControlSettings class that contains the <em>FileUploadComplete</em> static method to save the uploaded file itself and its path to the <em>resultFilePath </em>variable. Also, in this class, implement the <em>UploadValidationSettings</em> property that returns UploadControl validation settings. <br>3. Map UploadControl's CallbackRouteValues property to the UploadControlUpload action. In this action, call the <a href="https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.UploadControlExtension.GetUploadedFiles(DevExpress.Web.Mvc.UploadControlSettings-System.EventHandler-DevExpress.Web.FileUploadCompleteEventArgs-)">UploadControlExtension.GetUploadedFiles(UploadControlSettings,EventHandler<FileUploadCompleteEventArgs>)</a> method to pass UploadControl validation settings and invoke your FileUploadComplete method. <br>4. In the GridViewPartial action, get the DataTable object using the helper class and pass this table as a model to your _GridViewPartial.<br><strong><br>Note:</strong></p>
<p>The DevExpress.Docs assembly is used in this example. So, the <a href="https://www.devexpress.com/Products/NET/Document-Server/">Document Server</a> subscription license is required to implement the demonstrated approach.<br><br><strong>See also:</strong><br><a href="https://www.devexpress.com/Support/Center/p/E5199">How to load an excel file to the server using ASPxUploadControl and display its data in ASPxGridView</a></p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-mvc-grid-upload-and-display-excel-file&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-mvc-grid-upload-and-display-excel-file&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
