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

        public ActionResult Index(bool partial = false)
        {
            int user = 0;
            string name = "Guest";
            ViewBag.isManager = 0;
            if (Session["user"] is user)
            {
                user = (Session["user"] as user).id;
                name = (Session["user"] as user).name;
                ViewBag.isManager = Convert.ToInt32((Session["user"] as user).user_or_manager);
            }
            if (Session["user"] == null)
                user = -1;
            ViewBag.id = user;
            ViewBag.name = name;
            recipe r = new recipe();
            if (partial)
            {
                return PartialView();
            }
            else
            {
                return View();
            }
        }
        public ActionResult Welcome()
        {
            return PartialView();
        }
        
        public ActionResult createRecipe()
        {
            return View();
        }
         
        public ActionResult newRecipe()
        {
            if(Session["user"] is user)
                return PartialView();
            return  RedirectToAction("forbidden");
        }
        
        public ActionResult addProduct()
        {
            if (Session["user"] is user)
                return PartialView();
            return RedirectToAction("forbidden");
        }
         
        public ActionResult addRecipeForProduct()
        {
            if (Session["user"] is user)
                return PartialView();
            return RedirectToAction("forbidden");
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
        public ActionResult find()
        {
            return PartialView();
        }
        public ActionResult forbidden()
        {
            return PartialView();
        }
    }
}
