using BilijarKlub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilijarKlub.Helpers
{
    public class RezervacijaHelper
    {
        public UpdateInfo GetUpdate(RezervacijaViewModel rezervacija)
        {
            var result = new UpdateInfo
            {
                RezervacijaId = rezervacija.Id,
                New = true,
                Update = "Test",
                Finished = true
            };

            return result;
        }
    }
}