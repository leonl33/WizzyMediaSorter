using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using WizzyMediaSorter.Models;

namespace WizzyMediaSorter.Controllers
{
    public class CreatePlaylistController : SurfaceController 
    {
        [HttpPost]
        public ActionResult createPlaylistContent(CreatePlaylistModel model)
        {
            var contentService = Services.ContentService;

            var parentId = Guid.Parse("cc037cec-dabb-473b-baa1-45021f782d77");

            var playlist = contentService.Create(model.PlayListName, parentId, "createdPlaylist");

            contentService.SaveAndPublish(playlist);

            return Redirect("/playlist");
        }
    }
}