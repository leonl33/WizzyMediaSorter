using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace WizzyMediaSorter.Controllers
{
    public class DeleteMediaController : SurfaceController 
    {
        public ActionResult DeleteMyMedia(FormCollection collection)
        {
            var getId = Convert.ToInt32(collection.Get("deleteMedia"));

            var getNode = Services.MediaService.GetById(getId);

            Services.MediaService.Delete(getNode);

            return Redirect("/media");
        }
    }
}