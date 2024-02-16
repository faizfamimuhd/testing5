using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testing5.Models;

namespace testing5.Controllers
{
    public class JenisAduanController : Controller
    {
        // GET: JenisAduan
        public List<SelectListItem> JenisAduan(int Item=0)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            List<dbo_tbl_jenis_aduan> listAduan = new List<dbo_tbl_jenis_aduan>();

            using (testDBEntities conn = new testDBEntities())
            {
                listAduan = conn.dbo_tbl_jenis_aduan.ToList();
                foreach (var fe in listAduan)
                {
                    list.Add(new SelectListItem
                    {
                        Text = fe.JenisAduan,
                        Value = fe.IdAduan.ToString()
                    });
                }
            }

            return list;
        }
    }
}