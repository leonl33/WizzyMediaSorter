using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Core;


namespace WizzyMediaSorter.Controllers
{
    public class UploadMediaController : SurfaceController
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadMediaContent()
        {
            if(Request.Files != null && Request.Files.Count > 0)
            {
                foreach(var key in Request.Files.AllKeys)
                {
                    var file = Request.Files[key];

                    var newMedia = Services.MediaService.CreateMedia(file.FileName, -1, Constants.Conventions.MediaTypes.File);
                    newMedia.SetValue(Services.ContentTypeBaseServices, Constants.Conventions.Media.File, file.FileName, file);
                    Services.MediaService.Save(newMedia);

            


                }
            }

            return Redirect("/media");
        }
    }
}