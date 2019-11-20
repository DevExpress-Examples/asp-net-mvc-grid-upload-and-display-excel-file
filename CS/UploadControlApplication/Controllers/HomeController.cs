using DevExpress.Web.Mvc;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using UploadControlApplication.Models;

namespace UploadControlApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        HelperClass helperClass = new HelperClass();

        public ActionResult UploadControlUpload()
        {
            UploadControlExtension.GetUploadedFiles("UploadControl", HomeControllerUploadControlSettings.UploadValidationSettings, HomeControllerUploadControlSettings.FileUploadComplete);
            return null;
        }

        public ActionResult GridViewPartial()
        {
            var model = string.IsNullOrEmpty(HomeControllerUploadControlSettings.resultFilePath) ? null : helperClass.GetTableFromExcel();
            return PartialView("_GridViewPartial", model);
        }
    }

    public class HomeControllerUploadControlSettings
    {
        public const string UploadDirectory = "~/UploadFolder/";
        public static DevExpress.Web.UploadControlValidationSettings UploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".xls", ".xlsx" },
            MaxFileSize = 4000000
        };
        public static string resultFilePath = String.Empty;
        public static void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (e.UploadedFile.IsValid)
            {
                resultFilePath = HttpContext.Current.Request.MapPath(UploadDirectory + e.UploadedFile.FileName);
                e.UploadedFile.SaveAs(resultFilePath, true);
                IUrlResolutionService urlResolver = sender as IUrlResolutionService;
                if (urlResolver != null)
                {
                    e.CallbackData = urlResolver.ResolveClientUrl(resultFilePath);
                }

            }
        }
    }
}