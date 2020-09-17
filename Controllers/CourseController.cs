using ICMATESTMOCKMVC.BAL.GenericModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICMATESTMOCKMVC.Controllers
{
    public class CourseController : Controller
    {
        public actionModels actionModel;
        public CourseController()
        {
            actionModel = new actionModels();
        }
        // GET: Course
        public ActionResult Index()
        {
            var list = actionModel.listOfCourses();
            return View(list);
        }

        public ActionResult AddCourse(int id = 0)
        {
            if(id == 0)
            {
                ViewBag.function = "Add Course";
                return View(new viewModel());
            }
            return View();
            
        }

        [HttpPost]
        public ActionResult AddCourse(viewModel model)
        {
            actionModel.addCourse(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            return View();
        }
    }
}