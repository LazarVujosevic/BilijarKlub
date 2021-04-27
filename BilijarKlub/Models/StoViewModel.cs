using BusinessLogicLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilijarKlub.Models
{
    public class StoViewModel : BaseViewModel
    {
        public string Naziv { get; set; }

        public string Opis { get; set; }

        private StoBO _stoBO;

        public StoViewModel()
        {
            this._stoBO = new StoBO();
        }

        public void InsertSto(StoViewModel sto)
        {
            this._stoBO.InsertSto(new StoBO { Naziv = sto.Naziv, Opis = sto.Opis, IsDeleted = false });
        }

        public List<StoViewModel> GetStolova()
        {
           var listaStolovaBo = this._stoBO.GetStolova();

            var listaStolovaViewModel = new List<StoViewModel>();

            if (listaStolovaBo?.Count() > 0)
            {
                foreach (var stoBo in listaStolovaBo)
                {
                    listaStolovaViewModel.Add(new StoViewModel { Id = stoBo.Id, IsDeleted = stoBo.IsDeleted, Naziv = stoBo.Naziv, Opis = stoBo.Opis });
                }

                return listaStolovaViewModel;
            }

            return null;
        }
    }
}