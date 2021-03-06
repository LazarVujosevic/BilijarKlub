using BilijarKlub.Hubs;
using BilijarKlub.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilijarKlub.Controllers
{
    [System.Web.Mvc.Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new ZakazivanjeViewModel();

            var stoViewModel = new StoViewModel();

            viewModel.Stolovi = stoViewModel.GetStolova();

            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ZakazivanjeViewModel model)
        {
            var stoViewModel = new StoViewModel();
            model.Stolovi = stoViewModel.GetStolova();
            if (!ModelState.IsValid)
            {                
                return View(model);
            }

            var rezervacija = new RezervacijaViewModel((DateTime)model.Rezervacija.PocetakTermina, (DateTime)model.Rezervacija.KrajTermina);

            var saveResult = rezervacija.InsertRezervacija(model.Rezervacija);

            if (!saveResult.Item1 && saveResult.Item3.Count() > 0)
            {
                foreach (var item in saveResult.Item3)
                {
                    model.Rezervacija.ValidationRulesMessages.Add(item);
                }

                return View(model);
            }

            model.Rezervacija.NazivStola = model.Stolovi.Where(x => x.Id == model.Rezervacija.StoId).Select(a => a.Naziv).FirstOrDefault();
            var context = GlobalHost.ConnectionManager.GetHubContext<RezervacijaHub>();
            context.Clients.All.dodajRezervaciju(model.Rezervacija.NazivStola, model.Rezervacija.PocetakTermina?.ToString("M/d/yyyy H:mm:ss tt"), model.Rezervacija.KrajTermina?.ToString("M/d/yyyy H:mm:ss tt"));
            return this.RedirectToAction("Index");
        }

        [System.Web.Mvc.Authorize(Roles = "Zaposleni")]
        public ActionResult Rezervacije()
        {
            ViewBag.Message = "Your application description page.";
            
            var rezervacijaList = new  List<RezervacijaViewModel>();

            var rezervacijaViewModel = new RezervacijaViewModel();

            rezervacijaList = rezervacijaViewModel.GetRezervacija();
            return View(rezervacijaList);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}