using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace WizzyMediaSorter.Controllers
{
    public class DeletePlaylistController : SurfaceController
    {
        [HttpPost]
        public ActionResult deleteMyPlaylist(FormCollection collection)
        {
            var getPlaylistNodeId = Convert.ToInt32(collection["playlistId"]);

            var getPlaylist = Services.ContentService.GetById(getPlaylistNodeId);

            Services.ContentService.Delete(getPlaylist);

            return Redirect("/playlist");
        }
    }
}