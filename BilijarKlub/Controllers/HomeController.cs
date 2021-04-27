using BilijarKlub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilijarKlub.Controllers
{
    [Authorize]
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

            //var isViewModelValid = rezervacija.Validate();

            //if (!isViewModelValid.Item1 && isViewModelValid.Item2.Count() > 0)
            //{
            //    foreach (var item in isViewModelValid.Item2)
            //    {
            //        model.Rezervacija.ValidationRulesMessages.Add(item);
            //    }

            //    return View(model);
            //}

            var saveResult = rezervacija.InsertRezervacija(model.Rezervacija);

            if (!saveResult.Item1 && saveResult.Item3.Count() > 0)
            {
                foreach (var item in saveResult.Item3)
                {
                    model.Rezervacija.ValidationRulesMessages.Add(item);
                }

                return View(model);
            }
            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = "Zaposleni")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var stoViewModel = new StoViewModel();

            //for (int i = 1; i <= 5; i++)
            //{
            //    stoViewModel.InsertSto(new StoViewModel { Naziv = $"Sto {i}", Opis = $"Opis stola {i}", IsDeleted = false });
            //}

            stoViewModel.GetStolova();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}