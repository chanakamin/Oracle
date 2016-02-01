using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oracle.Models;
using System.Data;

namespace Oracle.Controllers
{
    public class DataController : Controller
    {
        private static recipeEntities recipes;
        static DataController ()
	    {
            recipes = new recipeEntities();
            //nutritional_value n = recipes.nutritional_value.Where(nt => nt.name == "sugar").First();
            //n.mustable = false;
            //recipes.SaveChanges();
	    }       
        //
        // GET: /Data/
        [HttpGet]
        public JsonResult getLists()
        {
            var ans =new {success = true,
                          products =  getProducts().Data,
                          details = getDetails().Data,
                          recipes = getRecipes().Data};
            return Json(ans, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public JsonResult getProducts(string where="")
        {
            int id;
            if (Session["user"] is user)
            {
                id = (Session["user"] as user).id;
            }
            else
                id = 0;
            List<nutritional_value_details> nutritionalDetails = recipes.nutritional_value_details.ToList();
            List<product> products = recipes.products.Where(p=>p.approved==true || p.user_id == id).ToList();
            products = products.Select(p => p.getSerialize()).ToList();
            var prod = products.Select(p => new { product = p, nutritional = nutritionalDetails.Where(nv => nv.product_id == p.id).ToList() }).ToList();            
            return Json( prod , JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getDetails()
        {
            var nvv = recipes.nutritional_value.Where(nv => nv.mustable).ToList();
            return Json(
                new {measureTypes = recipes.measure_type.ToList().Select(t=>t.getSerialize()).ToList(),
                     measurements = recipes.measurement_with_type,
                     nutritionalValues = nvv.Select(nv=>nv.getSerialize()).ToList(),
                    // recipes = recipes.recipes,
                     userId = Session["userId"]},
                JsonRequestBehavior.AllowGet
                );
        }

        [HttpGet]
        public JsonResult getRecipes()
        {
            int id;
            if (Session["user"] is user)
            {
                id = (Session["user"] as user).id;
            }
            else
                id = 0;
            List<recipe> recipe = recipes.recipes.Where(r => r.approved == true || r.user_id == id).ToList();
            recipe = recipe.Select(r => r.getSerialize()).ToList();
            
            return Json(recipe,JsonRequestBehavior.AllowGet);
        }
        // post request - add to db
        [HttpPost]
        public JsonResult addProduct(Product addProduct, NutritonalValue_for_product[] nutritionals, string Volume = null, string Weight = null)
        {
            product p = addProduct.getEntity();
            var pr = recipes.Entry(p);
            pr.State = EntityState.Added;
            pr.Entity.setMeasurements(Volume, Weight);
            List<products_in_nutritional_value> nutritionalsVal = nutritionals.Select(n => n.getEntity()).ToList();
            pr.Entity.products_in_nutritional_value = nutritionalsVal;
            recipes.SaveChanges();
            return Json(new { success = true, p = p.getSerialize() });
        }
        [HttpPost]
        public JsonResult addRecipe(recipe recipe,equipment_in_recipe[] equipments, products_in_recipe[] products_in_recipe)
        {
            var r = recipes.Entry(recipe);
            r.State = EntityState.Added;
            r.Entity.equipment_in_recipe = equipments;
            recipes.SaveChanges();
            r.Entity.isApproved();
            recipes.SaveChanges();
            r.Entity.products_in_recipe = products_in_recipe;
            recipes.SaveChanges();
            //recipe.equipment_in_recipe =  equipments;
            //recipe.products_in_recipe = products_in_recipe;
            //recipe.isApproved();
            //recipes.recipes.Add(recipe);
            //recipes.SaveChanges();
            return Json(new { success = true, recipe = recipe.getSerialize() });            
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
