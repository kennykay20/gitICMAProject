using ICMATESTMOCKMVC.BAL.GenericModel.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICMATESTMOCKMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public actionModels actionModel;
        public UserController()
        {
            actionModel = new actionModels();
        }
        public ActionResult Index()
        {
            var list = actionModel.listOfUsers();

            return View(list);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if(id == 0)
            {
                ViewBag.function = "Add User";
                return View(new viewUsers());
            }
            else
            {
                ViewBag.function = "Edit User";
                var user = actionModel.getUserById(id);
                return View(user);
            }
        }

        [HttpPost]
        public JsonResult AddOrEdit(viewUsers model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        model.imagePath = "~/Images/" + fileName;
                        model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images/"), fileName));
                    }
                    if (model.Id == 0)
                    {
                        actionModel.addUserData(model);
                        return Json(new { success = true, message = "saved user successfully" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        actionModel.updateUser(model);
                        return Json(new { success = true, message = "user updated successfully" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message}, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult Delete(int? id)
        {
            var user = actionModel.getUserById(Convert.ToInt16(id));
            if (user != null)
            {
                actionModel.deleteUser(user);
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, message = "" }, JsonRequestBehavior.AllowGet);
            //Json(new { success = false, message = ""}, JsonRequestBehavior.AllowGet);
        }
        public ActionResult addTest()
        {
            return View();
        }
    }
}