using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BCErp.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFiles()
        {
            try
            {
                HttpPostedFileBase attachFile = Request.Files[0];
                Stream streamObj = attachFile.InputStream;
                byte[] buffer = new byte[attachFile.ContentLength];
                streamObj.Read(buffer, 0, buffer.Length);
                streamObj.Close();
                streamObj = null;

                string ftpurl = String.Format("{0}/{1}", "ftp://localhost", attachFile.FileName);
                var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                requestObj.Credentials = new NetworkCredential("tpcftpuser", "SystemAdmin");
                var requestStream = requestObj.GetRequestStream();
                requestStream.Write(buffer, 0, buffer.Length);
                requestStream.Flush();
                requestStream.Close();
                requestObj = null;
                return Json("File Uploaded Successfully!");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }


    }
}