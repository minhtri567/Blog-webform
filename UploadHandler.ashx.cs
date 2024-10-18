using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BTLBlog
{
    /// <summary>
    /// Summary description for UploadHandler
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                HttpPostedFile file = context.Request.Files["upload"];
                if (file != null && file.ContentLength > 0)
                {
                    string folderPath = context.Server.MapPath("~/ImagesUploaded/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string fileName = Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(folderPath, fileName);
                    file.SaveAs(filePath);

                    // Trả về JSON cho CKEditor với URL của ảnh
                    var imageUrl = context.Request.Url.GetLeftPart(UriPartial.Authority) + "/ImagesUploaded/" + fileName;
                    context.Response.ContentType = "application/json";
                    context.Response.Write("{\"url\":\"" + imageUrl + "\"}");
                }
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.Write("{\"error\":\"" + ex.Message + "\"}");
            }
        }

        public bool IsReusable => false;
    }
}