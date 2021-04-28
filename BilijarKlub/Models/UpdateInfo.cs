using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilijarKlub.Models
{
    public class UpdateInfo
    {
        public int RezervacijaId { get; set; }

        public bool New { get; set; }

        public string Update { get; set; }

        public bool Finished { get; set; }
    }
}