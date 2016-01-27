using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oracle.Models;
using System.Web.Security;

namespace Oracle.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        static recipeEntities re;
        static LoginController() {
            re = new recipeEntities();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult existUser(string name, string password,string email) {
            bool can = true;
            user user = null;
            string reason = "This User doen't exists";            
            var c = re.users.Where(u => u.name == name && u.password == password).Count();
            if (c != 0) {
                can = false;
                reason = "This user already exist";
                user = re.users.Where(u => u.name == name && u.password == password).First();
                Session["user"] = user;
            }
            else if(email != null)
            {
                c = re.users.Where(u => u.email == email).Count();
                if (c != 0) {
                    can = false;
                    reason = "This email address already exists";
                }
            }
            if (user != null)
                user = user.getSerialize();
            var ob = new { can = can, reason = reason, exist = !can, user = user};
            return Json(ob, JsonRequestBehavior.AllowGet); 
        }

        [HttpPost]
        public JsonResult addUser(user user)
        {
            var success = true;
            if (TryUpdateModel(user))
            {
                re.users.Add(user);
                //Membership.CreateUser(user.name, user.password);
                re.SaveChanges();               
            }
            else
            {
                success = false;
            }
            return Json(new { success = success,id = user.id, user = user.getSerialize() },JsonRequestBehavior.AllowGet);
        }
        public ActionResult allRecipes() {
            return View();
        }

        public ActionResult changePart(string part) 
        {  RedirectToRoute(part,new {partial = true});
            return RedirectToAction("Index", part,new System.Web.Routing.RouteValueDictionary(new {partial = true}));    
        }
        public ActionResult register(user user)
        {
            if (TryUpdateModel(user))
            {
                Session["user"] = user;
            }
            else
                Session["user"] = null;
            return Json("success", JsonRequestBehavior.AllowGet);
        }
    }
}
