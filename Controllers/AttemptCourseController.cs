using ICMATESTMOCKMVC.BAL.GenericModel.ViewModel;
using ICMATESTMOCKMVC.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICMATESTMOCKMVC.Controllers
{
    public class AttemptCourseController : Controller
    {
        public actionModels actionModel;
        public viewAttemptCourse attemptCourse;
        public AttemptCourseController()
        {
            actionModel = new actionModels();
            attemptCourse = new viewAttemptCourse();
        }
        // GET: AttemptCourse
        public ActionResult Index()
        {
            var result = actionModel.listOfAttemptScores();
            return View(result);
        }

        public ActionResult AddOrEditAttemptCourse(int id = 0)
        {
            attemptCourse.drpUserList = actionModel.ListOfUsers();
            attemptCourse.drpCourseList = actionModel.ListOfCourses();

            return View(attemptCourse);
        }

        [HttpPost]
        public JsonResult AddOrEditAttemptCourse(string courseId, string userId, string score)
        {
            //decimal? scores = 0;
            var check = actionModel.getScoreById(userId);
            if (check)
            {
                return Json(new { error = false, message = "Score has already been added before!" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                tbl_AttemptCourse tbl = new tbl_AttemptCourse();
                tbl.userId = Convert.ToInt16(userId);
                tbl.courseId = Convert.ToInt16(courseId);
                tbl.Score = Convert.ToDecimal(score);
                actionModel.AddAttemptScore(tbl);

                return Json(new { error = false, message = "Score added successfully"}, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}