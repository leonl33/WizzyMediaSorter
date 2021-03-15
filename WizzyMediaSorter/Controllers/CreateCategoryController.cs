using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using WizzyMediaSorter.Models;

namespace WizzyMediaSorter.Controllers
{
    public class CreateCategoryController : SurfaceController 
    {
        [HttpPost]
        public ActionResult CategoryCreation(CreateCategoryModel model)
        {
            var contentService = Services.ContentService;

            var parentId = Guid.Parse("4c758747-08dd-4191-9d4f-9d26c36e024e");

            var category = contentService.Create(model.CategoryName, parentId, "category");

            contentService.SaveAndPublish(category);

            return Redirect("/categories");
        } 
    }


}