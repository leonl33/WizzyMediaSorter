using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Web.Mvc;
using static Umbraco.Core.Constants;

namespace WizzyMediaSorter.Controllers
{
    public class UpdateMediaController : SurfaceController 
    {
        [HttpPost]
        public ActionResult updatedMyMedia(FormCollection collection )
        {
            var mediaId = collection["mediaId"];
            var getContentId = collection["categoryId"];
            
           
            

            //form collection and convert to guid .Key

            if(getContentId != null && mediaId != null && getContentId != "")
            {

               var mediaIdToInt = Convert.ToInt32(collection["mediaId"]); //mediaId
               var getContentIdToInt = Convert.ToInt32(collection["categoryId"]);
                var categoryId = Umbraco.Content(getContentId).Key; //categoryId

                //create UDI from category Key
                var udi = Udi.Create(UdiEntityType.Document, categoryId);

                ////get Media item from media service

                var mediaItem = Services.MediaService.GetById(mediaIdToInt);

                ////setValue category property on media item to UDI of category

                mediaItem.SetValue("category", udi);

               
                ////save media Item
                Services.MediaService.Save(mediaItem);
            }

            

            ////return redirect

            return Redirect("/media");



        }
    }
}