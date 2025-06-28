using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.BLLModels;
using DTO.DTOModels;

namespace TidsregistreringMedarbejder.Controllers
{
    public class RegistreringController : Controller
    {

        public ActionResult Index()
        {
            var registreringer = BLLRegistrering.HentAlleRegistreringer()
                .Where(r => r.MedarbejderInitialer == "abc") 
                .Where(r => GetUgeStart(r.StartTid) == GetUgeStart(DateTime.Now))
                .ToList();

            ViewBag.Registreringer = registreringer;

            var sager = BLLSag.HentAlleSager();
            ViewBag.Sager = new SelectList(sager, "SagsNr", "Overskrift");

            return View(new DTORegistrering());
        }


        [HttpPost]
        public ActionResult Opret(DTORegistrering dto)
        {
            if (dto.StartTid >= dto.SlutTid)
            {
                ModelState.AddModelError("SlutTid", "Sluttidspunkt skal være efter starttidspunkt");
            }

            if (ModelState.IsValid)
            {
                BLLRegistrering.OpretRegistrering(dto);
                return RedirectToAction("Index");
            }

            ViewBag.Sager = new SelectList(BLLSag.HentAlleSager(), "SagsNr", "Overskrift");
            ViewBag.Registreringer = BLLRegistrering.HentAlleRegistreringer()
                .Where(r => r.MedarbejderInitialer == "abc")
                .Where(r => GetUgeStart(r.StartTid) == GetUgeStart(DateTime.Now))
                .ToList();

            return View("Index", dto);
        }

        private DateTime GetUgeStart(DateTime dato)
        {
            var diff = (7 + (dato.DayOfWeek - DayOfWeek.Monday)) % 7;
            return dato.AddDays(-1 * diff).Date;
        }
    }
}
