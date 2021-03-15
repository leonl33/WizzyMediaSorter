using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace WizzyMediaSorter.Controllers
{
    public class updatePlaylistController : SurfaceController
    {
        [HttpPost]
        public ActionResult updateMyPlaylist(FormCollection collection)
        {
            var getId = Convert.ToInt32(collection["playlistId"]);

            var getPlaylistNode = Services.ContentService.GetById(getId);

            getPlaylistNode.Name = collection["userInputTitle"];

            Services.ContentService.SaveAndPublish(getPlaylistNode);

            return Redirect("/playlist");
        }
    }
}