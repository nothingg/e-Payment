using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Configuration;
using System.Data;
using Newtonsoft.Json;
using log4net;
using System.Collections;
using AnyID.Models;
using AnyID.Class;

namespace AnyID.Controllers
{
    public class RegisterController : Controller
    {
        private RegisterModel RegisterModel;
        private static readonly log4net.ILog log =  log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        [Permission]
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }

        [Permission]
        [HttpPost]
        public ActionResult Index(RegisterModel Input)
        {
            try
            {
                if (RegisterModel.ChkFormatAcct(Input.AcctNumber) == true)
                {
                    using (OracleContext db = new OracleContext())
                    {
                        var Getrs = db.ANYID_GET_DATA_CBS(Input.AcctNumber);
                        List<ANYID_DATA_CBS> rs = Getrs.ToList();
                        ANYID_DATA_CBS rsOne = rs.FirstOrDefault();
                        if (rsOne != null)
                        {
                            rsOne = RegisterModel.CovertNameCustomerTo32Char(rsOne);

                            var GetMobile = db.ANYID_GET_MOBILE_CBS(Convert.ToString(rsOne.ACCOUNTID));
                            Hashtable htMobile = RegisterModel.GetListMobile(GetMobile.ToList());
                            ViewBag.HomeMobile = htMobile["HomeMobile"];
                            ViewBag.WorkMobile = htMobile["WorkMobile"];
                            ViewBag.MailingMobile = htMobile["MailingMobile"];

                            ViewBag.HaveJoint = (rsOne.COUNT_JOINT > 1) ? "มี" : "ไม่มี";
                            ViewBag.FrezDesc = RegisterModel.GetFrezDesc(Convert.ToString(rsOne.FREZ_CODE));
                            ViewBag.AcctStatusDormant = RegisterModel.GetAcctStatusDesc(Convert.ToString(rsOne.ACCT_STATUS_DORMANT));
                            ViewBag.AcctClsFlg = RegisterModel.GetAcctClsDesc(Convert.ToString(rsOne.ACCT_CLS_FLG));
                            
                        }
                        else
                        {
                            TempData["Notify"] = Constants.NotifyTrue.ToString();
                            TempData["Class"] = Constants.ClassError.ToString();
                            TempData["Message"] = Constants.MsgNoData.ToString();

                            return RedirectToAction("Index");
                        }

                        /*** Log ***/
                        RegisterModel.LogsInsert(DateTime.Now,rsOne , null);

                        ViewBag.AccountNumber = Input.AcctNumber;
                        return View("Index", rsOne);
                    }
                }
                else 
                {
                    TempData["Notify"] = Constants.NotifyTrue.ToString();
                    TempData["Class"] = Constants.ClassError.ToString();
                    TempData["Message"] = Constants.MsgNotAcctDeposit.ToString();
                    return RedirectToAction("Index");
                }
                
                
            }
            catch (Exception e) 
            {
                TempData["Notify"] = Constants.NotifyTrue.ToString();
                TempData["Class"] = Constants.ClassError.ToString();
                TempData["Message"] = Constants.MsgError.ToString();
                log.Error(CommonHelper.ErrMsg(e));
                return RedirectToAction("Index");
            }
            
        }

        [Permission]
        [HttpPost]
        public ActionResult InsertNewAccount()
        {
            DateTime dt = DateTime.Now;
            try 
            {
                ANYID_DATA_ITMX item = new ANYID_DATA_ITMX();
                item.PROXY_TYPE = Request.Form["ITMXProxyType"];
                item.PROXY_VALUE = (item.PROXY_TYPE == "MSISDN") ? "+66" + Request.Form["ITMXProxyValue"].Substring(1, Request.Form["ITMXProxyValue"].Length - 1) : Request.Form["ITMXProxyValue"];
                item.ACCOUNT_TYPE = "DUMMY";
                item.ACCOUNT_NUMBER = Request.Form["AccountNumber"]; // Bank Code + เลขบัญชี Dummy
                item.ACCOUNT_NAME = Request.Form["ITMXAcctName"];
                item.DISPLAY_NAME = Request.Form["ITMXDisplayName"];
                item.PERSON_FIRSTNAME = Request.Form["ITMXFirstName"];
                item.PERSON_LASTNAME = Request.Form["ITMXSecondName"];
                item.PERSON_LASTNAME = Request.Form["ITMXLastName"];
                item.BUSINESS_NAME = Request.Form["ITMXBusinessName"];
                if (Request.Form["ITMXBusinessRegisterDate"] != "") { 
                    item.BUSINESS_REGISTERED_DATE = DateTime.ParseExact(Convert.ToString(Request.Form["ITMXBusinessRegisterDate"]), "dd-MM-yyyy", CultureInfo.InvariantCulture); 
                }

                item.CREATED_DATE = dt;
                item.CREATED_USER = Convert.ToString(Session["UserID"]) ; /* ดึงจาก Session*/
                
                item.REGISTRATION_STATUS = "Active";

                using (OracleContext db = new OracleContext())
                {
                    var QueryHaveDataInAnyID = from st in db.ANYID_DATA_ITMX
                                   where st.PROXY_TYPE == item.PROXY_TYPE && st.PROXY_VALUE == item.PROXY_VALUE
                                   select st;
                    int CountHaveDataInAnyID = QueryHaveDataInAnyID.Count();

                    var QueryRegis3Mobile = from m in db.ANYID_DATA_ITMX
                                            where m.ACCOUNT_NUMBER == item.ACCOUNT_NUMBER && m.PROXY_TYPE == "MSISDN"
                                            select m;
                    int CountRegis3Mobile = QueryRegis3Mobile.Count();

                    if (CountHaveDataInAnyID == 0 && CountRegis3Mobile < 3)
                    {
                        db.AddToANYID_DATA_ITMX(item);
                        db.SaveChanges();

                        /**** Log *****/
                        RegisterModel.LogsInsert(dt, null, item);
                        /**** !Log *****/

                        TempData["Notify"] = Constants.NotifyTrue.ToString();
                        TempData["Class"] = Constants.ClassSuccess.ToString();
                        TempData["Message"] = Constants.MsgSaveSuccess.ToString();
                    }
                    else
                    {
                        TempData["Notify"] = Constants.NotifyTrue.ToString();
                        TempData["Class"] = Constants.ClassError.ToString();
                        TempData["Message"] = (CountRegis3Mobile >= 3) ? Convert.ToString(Constants.MsgMoreLimit) : Convert.ToString(Constants.MsgHaveData);
                    }
                    return RedirectToAction("Index");
                }
            }
            catch( Exception e)
            {
                TempData["Notify"] = Constants.NotifyTrue.ToString();
                TempData["Class"] = Constants.ClassError.ToString();
                TempData["Message"] = Constants.MsgError.ToString();
                log.Error(CommonHelper.ErrMsg(e));
                return RedirectToAction("Index");
            }
        }


       
        /*
        [Permission]
        public void ListLogs()
        {
            OracleContext db = new OracleContext();
            ANYID_LOGS row =  db.ANYID_LOGS.ToList().FirstOrDefault();
            ANYID_DATA_CBS rsOne = JsonConvert.DeserializeObject<ANYID_DATA_CBS>(row.LOG_DATA);
        }*/
    }
}
