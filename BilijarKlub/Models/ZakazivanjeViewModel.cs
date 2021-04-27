using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilijarKlub.Models
{
    public class ZakazivanjeViewModel
    {
        public List<StoViewModel> Stolovi { get; set; }

        public RezervacijaViewModel Rezervacija { get; set; }

        public ZakazivanjeViewModel()
        {
            this.Stolovi = new List<StoViewModel>();

            this.Rezervacija = new RezervacijaViewModel();
        }
    }
}