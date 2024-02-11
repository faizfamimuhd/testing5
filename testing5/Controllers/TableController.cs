
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using testing5.Models;

namespace testing5.Controllers
{
    public class TableController : Controller
    {
        // GET: Table
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ciptaAduanView()
        {
            return View();
        }

        public ActionResult GetList() 
        {
            using (testDBEntities db = new testDBEntities())
            {
                var aduanList = db.tbl_aduan_whatsapp.ToList<tbl_aduan_whatsapp>();
                return Json(new { data = aduanList }, JsonRequestBehavior.AllowGet);
            }

        }

        public async Task<ActionResult> AddAsync(tbl_aduan_whatsapp model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new testDBEntities())
                {
                    try
                    {
                        var aduanbaru = new tbl_aduan_whatsapp();
                        DateTime todayDate = DateTime.Now.Date;
                        var runningNo = await db.tbl_aduan_whatsapp.AsNoTracking()
                                   .Where(e => e.Tarikh_Aduan == todayDate)
                                   .CountAsync() + 1;


                        var RefNo = "W_" + todayDate.ToString("yyyyMMdd") + "_" + runningNo;


                        #region aduan
                        aduanbaru.RefNo = RefNo;
                        aduanbaru.Pengadu = model.Pengadu;
                        aduanbaru.AduanWhatsapp = model.AduanWhatsapp;
                        aduanbaru.Tindakan = model.Tindakan;
                        aduanbaru.Tarikh_Aduan = todayDate;
                        db.tbl_aduan_whatsapp.Add(aduanbaru);
                        db.SaveChanges();

                        #endregion


                        SetMessage(true, "Aduan telah berjaya ditambah");

                        return RedirectToAction("Index", "Table");
                    }
                    catch (Exception ex)
                    {
                        SetMessage(false, "Error: " + ex);
                    }
                }
            }
            else
            {
                SetMessage(true, "Sila lengkapkan maklumat");
            }
            return RedirectToAction("ciptaAduanView", "Table");
        }

        string SET_MESSAGE = "SET_MESSAGE";

        public void SetMessage(bool IsError, string message = "")
        {
            if (IsError)
            {
                //message = "<div class='form-group autoHide'><label class='control-label label-danger col-sm-12' style='text-align: left;margin: 10px 0px 10px 0px; padding: 10px;'><i class='fa fa-times-circle-o' style='margin-right:10px;'></i>" + message + "</label></div>";
                //message = "<img src hidden onload='errorModal(" + message + ")'></div>";
                message = "<div class='alert alert-danger autoHide'>" + message + "</div>";
            }
            else
            {
                //message = "<img src hidden onload=\"successModal('" + message + "')\"></div>";
                //message = "<div class='form-group autoHide'><label class='control-label label-info col-sm-12' style='text-align: left;margin: 10px 0px 10px 0px; padding: 10px;'><i class='fa fa-check-circle-o' style='margin-right:10px;'></i>" + message + "</label></div>";
                message = "<div class='alert alert-success autoHide'>" + message + "</div>";
            }

            TempData[SET_MESSAGE] = message;
        }

    }
}