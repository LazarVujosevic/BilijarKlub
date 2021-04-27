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
            RuleFor(x => x.PocetakTermina).Must(TerminNijeZauzet).WithMessage("Zeljeni tremin za navedeni sto je zauzet.");
        }

        private bool TerminNijeZauzet(RezervacijaBO rezervacijaBO, DateTime aa)
        {
            var rezervacije = rezervacijaBO.GetRezervacija();

            //var a = rezervacije.Where()
            return false;
        }
    }
}
