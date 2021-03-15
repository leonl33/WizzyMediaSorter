using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Web.Mvc;
using WizzyMediaSorter.Extension;
using static Umbraco.Core.Constants;

namespace WizzyMediaSorter.Controllers
{
    
    public class SelectPlaylistMediaController : SurfaceController 
    {

        [HttpPost]
        public ActionResult SelectMyMedia(int mediaId, int playlistId)
        {
            ////get media node
            
            var selectedMedia = Umbraco.Media(mediaId);

            ////get playlist
           
            var selectedPlaylist = Services.ContentService.GetById(playlistId); //return Icontent raw database type, call to database



            //add media node to media picker

            if (selectedMedia != null && selectedPlaylist != null)
            {
                //udi media item
                var udi = Udi.Create(UdiEntityType.Document, selectedMedia.Key);

                //get existing val of playlist media
                var mediaPicker = selectedPlaylist.GetValue<string>("mediaPicker") ?? ""; //?? fallback value if null empty string

                //take existing value and split on commas, removed empty entries 
                var udiList = mediaPicker.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                //added new UDI to list
                udiList.Add(udi.ToString());

                var newValue = string.Join(",", udiList);

                selectedPlaylist.SetValue("mediaPicker", newValue);
                Services.ContentService.SaveAndPublish(selectedPlaylist);

            }
            




            //return to playlist/edit?id=(playlistID)

            return Redirect($"/playlist/edit?id={playlistId}");
        }
    }
}