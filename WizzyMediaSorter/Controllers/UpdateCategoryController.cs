using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace WizzyMediaSorter.Controllers
{
    
    public class UpdateCategoryController : SurfaceController 
    {
        [HttpPost]
        public ActionResult updateMyCategory(FormCollection collection)
        {

            var contentId = Convert.ToInt32(collection["catId"]);

            var currentCategory = Services.ContentService.GetById(contentId);

            currentCategory.Name = collection["editCategoryVal"];
            Services.ContentService.SaveAndPublish(currentCategory);

            return Redirect("/categories");
        }
    }
}