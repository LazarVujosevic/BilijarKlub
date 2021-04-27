using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BusinessObjects
{
    public class StoBO : BaseBO
    {
        public string Naziv { get; set; }

        public string Opis { get; set; }

        public void InsertSto(StoBO sto)
        {
            this.entity.Insert("dbo.Sto", $"'{sto.Naziv}','{sto.Opis}', 0");
        }

        public List<StoBO> GetStolova()
        {
            var stoEntityList = (List<Sto>)this.entity.Get(new Sto());

            var stoBoList = new List<StoBO>();

            if (stoEntityList?.Count() > 0)
            {
                foreach (var stoEntity in stoEntityList)
                {
                    stoBoList.Add(new StoBO { Id = stoEntity.Id, IsDeleted = stoEntity.IsDeleted, Naziv = stoEntity.Naziv, Opis = stoEntity.Opis });
                }

                return stoBoList;
            }

            return null;
        }
    }
}
