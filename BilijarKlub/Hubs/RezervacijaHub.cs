using BilijarKlub.Helpers;
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
        public void Test(string sto, DateTime? pocetak, DateTime? kraj)
        {
            this.Send(sto,pocetak,kraj);
        }
        //    private static readonly RezervacijaHelper _rezervacijaHelper = new RezervacijaHelper();
        //    public async Task GetUpdateForRezervacija(RezervacijaViewModel rezervacija)
        //    {
        //        await Clients.Others.NovaRezervacija(rezervacija);
        //        UpdateInfo result;
        //        do
        //        {
        //            result = _rezervacijaHelper.GetUpdate(rezervacija);
        //            await Task.Delay(700);
        //            if (!result.New)
        //            {
        //                continue;
        //            }

        //            await Clients.Caller.ReceiveOrderUpdate(result);
        //            await Clients.Group("allUpdateReceivers").ReceiveRezervacijaUpdate(result);
        //        } while (!result.Finished);
        //    }


        //    public override Task OnConnected()
        //    {
        //        if (Context.QueryString["group"] == "allUpdates")
        //            Groups.Add(Context.ConnectionId, "allUpdateReceivers");
        //        return base.OnConnected();
        //    }
        public void Send(string sto, DateTime? pocetak, DateTime? kraj)
        {
            Clients.All.dodajRezervaciju(sto, pocetak, kraj);
        }

        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<RezervacijaHub>();
    }    
}