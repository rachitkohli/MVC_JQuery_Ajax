using MVCjqueryAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCjqueryAjax.Controllers
{
    public class PatientPopController : Controller
    {
        // GET: PatientPop
        Models.DemoCorePatientEntities patDB = new Models.DemoCorePatientEntities();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return Json(patDB.PatientMasters.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPatient(int id)
        {
            return Json(patDB.PatientMasters.Where(j => j.ID == id).FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(PatientMaster patient)
        {
            patDB.PatientMasters.Add(patient);
            patDB.SaveChanges();
            return Json(patient);
        }

        public JsonResult Update(PatientMaster patient)
        {
            var pat = patDB.PatientMasters.Where(j => j.ID == patient.ID).FirstOrDefault();
            pat.MRN = patient.MRN;
            pat.PatientName = patient.PatientName;
            pat.Sex = patient.Sex;
            pat.Age = patient.Age;
            pat.City = patient.City;
            patDB.SaveChanges();
            return Json(pat);
        }

        public JsonResult Delete(int id)
        {
            var pat = patDB.PatientMasters.Where(j => j.ID == id).FirstOrDefault();
            patDB.PatientMasters.Remove(pat);
            patDB.SaveChanges();
            return Json(null);
        }
    }
}