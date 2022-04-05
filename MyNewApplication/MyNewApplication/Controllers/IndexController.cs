using MyNewApplication.ComanHelper;
using MyNewApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNewApplication.Controllers
{
    public class IndexController : Controller
    {
        DBUserMasterConnect DMUC = new DBUserMasterConnect();
        // GET: Index
        public ActionResult CreateNewAccount()
        {
            return View();
        }
        public ActionResult UserRecord()
        {
            return View();
        }
        public ActionResult Chart()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateNewAccount(int Id, string FirstName, string LastName, string ContactNo, string EmailId, string password, char Gender)
        {
            int flag = 0;
            InsertRecord IR = new InsertRecord();
            {
                IR.Id = Id;
                IR.FirstName = FirstName;
                IR.LastName = LastName;
                IR.ContactNo = ContactNo;
                IR.EmailId = EmailId;                
                IR.Gender = Gender;
                IR.Password = password;
                IR.Gender = Gender;
                IR.Status = 'Y';
            }

            flag = DMUC.InsertRecord(IR);
            if (flag == 1)
            {
                var result = new { Success = "Success", Message = "Data Inserted Successfully .....!!" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = "False", Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public JsonResult GetAllUserData(string OrderBy, string WhereClause)
        {
            List<InsertRecord> Rlst = new List<InsertRecord>();
            Rlst = DMUC.GetUserData(OrderBy, WhereClause);
            return Json(new { data = Rlst }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateUserStatus1(int Id, char Status)
        {
            int flag = 0;
            InsertRecord IR = new InsertRecord();
            {
                IR.Id = Id;
                IR.Status = Status;
            };

            flag = DMUC.UpdateUserStatus(IR);
            if (flag == 1)
            {
                var result = new { Success = "Success", Message = "Status Updated Successfully..!!" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = "False", Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult ChartCall(string SelectAsLabel, string GroupBy)
        {
            List<UserChartResponseModel> ULst = new List<UserChartResponseModel>();
            ULst = DMUC.GetUserChartData(SelectAsLabel, GroupBy);
            return Json(new { data = ULst }, JsonRequestBehavior.AllowGet);
        }
    }
}
    
