<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128550826/19.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T576892)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# GridView - How to upload an Excel file via UploadControl and show its data in a grid

***Note***

In version **19.2**, we renamed our **Range** interface to **CellRange** - see the following BC for details: [The DevExpress.Spreadsheet.Range interface has been renamed to DevExpress.Spreadsheet.CellRange](https://supportcenter.devexpress.com/ticket/details/bc5125).

<p>This example shows how to load an Excel file from your computer to the server using <strong>MVCxUploadControl</strong> and then display its data in <strong>MVCxGridView</strong>. <br>Steps to implement this task are the following:<br>1. Implement the Helper class that returns the DataTable object based on your Excel file.<br>2. Implement the HomeControllerUploadControlSettings class that contains the <em>FileUploadComplete</em> static method to save the uploaded file itself and its path to the <em>resultFilePath </em>variable. Also, in this class, implement the <em>UploadValidationSettings</em> property that returns UploadControl validation settings. <br>3. Map UploadControl's CallbackRouteValues property to the UploadControlUpload action. In this action, call the <a href="https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.UploadControlExtension.GetUploadedFiles(DevExpress.Web.Mvc.UploadControlSettings-System.EventHandler-DevExpress.Web.FileUploadCompleteEventArgs-)">UploadControlExtension.GetUploadedFiles(UploadControlSettings,EventHandler<FileUploadCompleteEventArgs>)</a> method to pass UploadControl validation settings and invoke your FileUploadComplete method. <br>4. In the GridViewPartial action, get the DataTable object using the helper class and pass this table as a model to your _GridViewPartial.<br><strong><br>Note:</strong></p>
<p>The DevExpress.Docs assembly is used in this example. So, the <a href="https://www.devexpress.com/Products/NET/Document-Server/">Document Server</a> subscription license is required to implement the demonstrated approach.<br><br><strong>See also:</strong><br><a href="https://www.devexpress.com/Support/Center/p/E5199">How to load an excel file to the server using ASPxUploadControl and display its data in ASPxGridView</a></p>

<br/>

<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/UploadControlApplication/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/UploadControlApplication/Controllers/HomeController.vb))
* [HelperClass.cs](./CS/UploadControlApplication/Models/HelperClass.cs) (VB: [HelperClass.vb](./VB/UploadControlApplication/Models/HelperClass.vb))
* [_GridViewPartial.cshtml](./CS/UploadControlApplication/Views/Home/_GridViewPartial.cshtml)
* [Index.cshtml](./CS/UploadControlApplication/Views/Home/Index.cshtml)
<!-- default file list end -->
