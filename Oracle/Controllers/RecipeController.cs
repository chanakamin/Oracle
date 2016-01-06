using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oracle.Models;
using System.Data.Entity;

namespace Oracle.Controllers
{
    public class RecipeController : Controller
    {
        static recipeEntities recipes;

        static RecipeController()
        {            
            recipes = new recipeEntities();
        }
       
        //[HttpPost]
        //public JsonResult addCompany(string name)
        //{
        //    object answer = null;
        //    int idCamp = 0;
        //    if (String.IsNullOrEmpty(name))
        //        answer = new { success = false };
        //    else
        //    {
        //        idCamp = recipes.add_company(name);
        //        answer = new { success = true, id = idCamp};
        //    }
        //    return Json(answer);
        //}
        //
        // GET: /Recipe/
        //public JsonResult getData (string dataRequest, string filter = "all")
        //{
        //    JsonResult result = new JsonResult();
        //    switch (dataRequest)
        //    {
        //        case "company":
        //            result = Json(recipes.companies.ToArray(), JsonRequestBehavior.AllowGet);
        //            break;
        //        default:
        //            break;
        //    }
        //    return result;
        //}

        //public EmptyResult addData(string newData)
        //{
        //    EmptyResult e = new EmptyResult();
        //    return e;
        //}

        public ActionResult Index()
        {           
            Session.Add("userId",5);    
            recipe r = new recipe();
            return View();
        }
        public ActionResult createRecipe()
        {
            return View();
        }

        public ActionResult newRecipe()
        {
            return PartialView();
        }

        public ActionResult addProduct()
        {
            return PartialView();
        }
        public ActionResult addRecipeForProduct()
        {
            return PartialView();
        }
        public ActionResult nutritionalValues()
        {
            return PartialView();
        }
        public ActionResult allRecipes()
        {
            return PartialView();
        }
        public ActionResult showRecipe(int id)
        {
            return PartialView();
        }

    }
}
