using MVCjqueryAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCjqueryAjax.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllPatients());
        }

        public ActionResult AddorEdit(int id=0)
        {
            PatientMaster pat = new PatientMaster();
            return View(pat);
        }
            
        [HttpPost]
        public ActionResult AddorEdit(PatientMaster pat)
        {
            using (Models.DemoCorePatientEntities db = new DemoCorePatientEntities())
            {
                db.PatientMasters.Add(pat);
                db.SaveChanges();
            }
            return Redirect(Url.Action("ViewAll") + "#firsttab");
        }

        IEnumerable<PatientMaster> GetAllPatients()
        {
            using (Models.DemoCorePatientEntities db=new DemoCorePatientEntities())
            {
                return db.PatientMasters.ToList<PatientMaster>();
            }
        }
    }
}