using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oracle.Models;

namespace Oracle.Controllers
{
    public class DataController : Controller
    {
        private static recipeEntities recipes;
        static DataController ()
	    {
            recipes = new recipeEntities();
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
            List<nutritional_value_details> nutritionalDetails = recipes.nutritional_value_details.ToList();
            List<product> products = recipes.products.ToList();
            var prod = products.Select(p => new { product = p, nutritional = nutritionalDetails.Where(nv => nv.product_id == p.id).ToList() }).ToList();            
            return Json( prod , JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getDetails()
        {           
            return Json(
                new {measureTypes = recipes.measure_type,
                     measurements = recipes.measurement_with_type,
                     nutritionalValues = recipes.nutritional_value.Where(nv => nv.mustable),
                    // recipes = recipes.recipes,
                     userId = Session["userId"]},
                JsonRequestBehavior.AllowGet
                );
        }

        [HttpGet]
        public JsonResult getRecipes()
        { 
            List<recipe> recipe = recipes.recipes.ToList();
           // var specialEquipments = recipes.equipment_in_recipe.Select(e => new { recipeId = e.recipe_id, equipment = e.special_equipment1 }).ToList();
            List<product> prod = recipes.products.ToList();
            var resp = recipe.Select(r => new
            {   recipe = r,
               // specialEquipments = specialEquipments.Where(e => e.recipeId == r.id).Select(e => e.equipment).ToArray(),
                prodId = prod.Where(p => p.id == r.id).Select(p => p.id).ToArray()
            }).ToList();
            return Json(resp,JsonRequestBehavior.AllowGet);
        }
        // post request - add to db
        [HttpPost]
        public JsonResult addProduct(Product addProduct, NutritonalValue_for_product[] nutritionals, string Volume = null, string Weight = null)
        {
            product p = addProduct.getEntity();
            p.setMeasurements(Volume, Weight);
            
            List<products_in_nutritional_value> nutritionalsVal = nutritionals.Select(n => n.getEntity()).ToList();
            p.products_in_nutritional_value = nutritionalsVal;
            recipes.products.Add(p);
            recipes.SaveChanges();
            return Json(new { success = true });
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
