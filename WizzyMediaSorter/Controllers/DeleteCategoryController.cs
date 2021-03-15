using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace WizzyMediaSorter.Controllers
{
    public class DeleteCategoryController : SurfaceController
    {
        public ActionResult deleteCategoryContent(FormCollection collection)
        {
            var getValue = Convert.ToInt32(collection["childId"]);
            var getId = Services.ContentService.GetById(getValue);

            Services.ContentService.Delete(getId);

            return Redirect("/categories");
        }
    }
}