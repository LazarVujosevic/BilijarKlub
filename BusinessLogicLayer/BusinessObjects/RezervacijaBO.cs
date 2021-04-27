using BusinessLogicLayer.BusinessRules;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BusinessObjects
{
    public class RezervacijaBO : BaseBO
    {
        public int StoId { get; set; }
        public DateTime PocetakTermina { get; set; }
        public DateTime KrajTermina { get; set; }

        public (bool, List<string>) InsertRezervacija(RezervacijaBO rezervacijaBO)
        {
            RezervacijaBOValidation validator = new RezervacijaBOValidation();

            var result = validator.Validate(rezervacijaBO);

            if (!result.IsValid)
            {
                var errorsList = new List<string>();
                foreach (var error in result.Errors)
                {
                    errorsList.Add(error.ErrorMessage);
                }

                return (false, errorsList);
            }

            return (true, new List<string>());
        }

        public List<RezervacijaBO> GetRezervacija()
        {
            var rezervacijaEntityList = (List<Rezervacija>)this.entity.Get(new Rezervacija());

            var rezervacijaBoList = new List<RezervacijaBO>();

            if (rezervacijaEntityList?.Count() > 0)
            {
                foreach (var rezervacijaEntity in rezervacijaEntityList)
                {
                    rezervacijaBoList.Add(new RezervacijaBO { Id = rezervacijaEntity.Id, PocetakTermina = rezervacijaEntity.PocetakTermina, KrajTermina = rezervacijaEntity.KrajTermina });
                }

                return rezervacijaBoList;
            }

            return null;
        }
    }
}
