using BusinessLogicLayer.BusinessObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BusinessRules
{
    public class RezervacijaBOValidation : AbstractValidator<RezervacijaBO>
    {
        public RezervacijaBOValidation()
        {
            RuleFor(x => x.StoId).Must(TerminNijeZauzet).WithMessage("Zeljeni tremin za navedeni sto je zauzet.");
        }

        private bool TerminNijeZauzet(RezervacijaBO rezervacijaBO, int stoId)
        {
            var rezervacije = rezervacijaBO.GetRezervacija(stoId, rezervacijaBO.PocetakTermina, rezervacijaBO.KrajTermina);

            if (rezervacije?.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}
