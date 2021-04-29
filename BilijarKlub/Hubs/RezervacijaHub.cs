using BilijarKlub.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BilijarKlub.Hubs
{
    public class RezervacijaHub : Hub
    {
        public void Send(string sto, DateTime? pocetak, DateTime? kraj)
        {
            Clients.All.dodajRezervaciju(sto, pocetak, kraj);
        }

        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<RezervacijaHub>();
    }
}