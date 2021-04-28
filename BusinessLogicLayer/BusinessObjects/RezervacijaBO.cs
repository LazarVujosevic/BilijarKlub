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

        public string NazivStola { get; set; }

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
            else
            {
                this.entity.Insert("dbo.Rezervacija", $"'{rezervacijaBO.StoId}','{rezervacijaBO.PocetakTermina}', '{rezervacijaBO.KrajTermina}'");
            }

            return (true, new List<string>());
        }

        public List<RezervacijaBO> GetRezervacija(int? stoId = null,DateTime? pocetakTermina = null, DateTime? krajTermina = null)
        {
            string whereClause = string.Empty;

            if (stoId != null && pocetakTermina != null && krajTermina != null)
            {
                whereClause = $"WHERE StoId = {stoId} AND ((PocetakTermina <= '{pocetakTermina}' AND KrajTermina >= '{pocetakTermina}') OR (PocetakTermina <= '{krajTermina}' AND KrajTermina >= '{krajTermina}'))";
            }
            var rezervacijaEntityList = (List<Rezervacija>)this.entity.Get(new Rezervacija(), whereClause);

            var rezervacijaBoList = new List<RezervacijaBO>();

            if (rezervacijaEntityList?.Count() > 0)
            {
                foreach (var rezervacijaEntity in rezervacijaEntityList)
                {
                    rezervacijaBoList.Add(new RezervacijaBO { StoId = rezervacijaEntity.StoId, PocetakTermina = rezervacijaEntity.PocetakTermina, KrajTermina = rezervacijaEntity.KrajTermina, NazivStola = rezervacijaEntity.Sto.Naziv });
                }

                return rezervacijaBoList;
            }

            return null;
        }
    }
}
