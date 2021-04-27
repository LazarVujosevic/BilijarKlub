using BusinessLogicLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilijarKlub.Models
{
    public class RezervacijaViewModel : BaseViewModel
    {
        [CustomValidation(typeof(RezervacijaViewModel), "ValidateSto", ErrorMessage = "Neophodno je izabrati sto")]
        public int StoId { get; set; }

        [Required(ErrorMessage = "Pocetak termina je obavezan podatak")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? PocetakTermina { get; set; }

        [Required(ErrorMessage = "Kraj termina je obavezan podatak")]
        //[CustomValidation(typeof(RezervacijaViewModel), "KrajTerminaNijePrePocetka", ErrorMessage = "Neophodno je izabrati sto")]
        public DateTime? KrajTermina { get; set; }

        private RezervacijaBO _rezervacijaBO { get; set; }

        public RezervacijaViewModel()
        {

        }
        public RezervacijaViewModel(DateTime pocetakTermina, DateTime krajTermina)
        {
            this.PocetakTermina = pocetakTermina;
            this.KrajTermina = krajTermina;
            this._rezervacijaBO = new RezervacijaBO();
        }

        #region Validation Rules
        public static ValidationResult ValidateSto(int x, ValidationContext context)
        {
            return (x == -1)
                ? new ValidationResult(null)
                : ValidationResult.Success;
        }

        //public (bool, List<string>) Validate()
        //{
        //    var validate = new ValidateViewModel
        //    {
        //        PocetakTerminaProperty = (DateTime)this.PocetakTermina,
        //        KrajTerminaProperty = (DateTime)this.KrajTermina
        //    };

        //    bool validateAllProperties = false;

        //    var results = new List<ValidationResult>();

        //    bool isValid = Validator.TryValidateObject(
        //        validate,
        //        new ValidationContext(validate, null, null),
        //        results,
        //        validateAllProperties);

        //    return (isValid, results.Select(x => x.ErrorMessage).ToList());
        //}

        public (bool, bool, List<string>) InsertRezervacija(RezervacijaViewModel rezervacijaViewModel)
        {
            //ViewModel validacija

            var validate = new ValidateViewModel
            {
                PocetakTerminaProperty = (DateTime)this.PocetakTermina,
                KrajTerminaProperty = (DateTime)this.KrajTermina
            };

            bool validateAllProperties = false;

            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(
                validate,
                new ValidationContext(validate, null, null),
                results,
                validateAllProperties);

            if (!isValid)
            {
                return (false, isValid, results.Select(x => x.ErrorMessage).ToList());
            }

            else
            {
                var boSaveResult = this._rezervacijaBO.InsertRezervacija(new RezervacijaBO { StoId = rezervacijaViewModel.StoId, PocetakTermina = (DateTime)rezervacijaViewModel.PocetakTermina, KrajTermina = (DateTime)rezervacijaViewModel.KrajTermina });

                if (!boSaveResult.Item1)
                {
                    return (false, boSaveResult.Item1, boSaveResult.Item2);
                }
            }

            return (true, true, new List<string>());
        }

        private class ValidateViewModel : IValidatableObject
        {
            public DateTime PocetakTerminaProperty { get; set; }

            public DateTime KrajTerminaProperty { get; set; }

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                var results = new List<ValidationResult>();
                if (PocetakTerminaProperty != null && KrajTerminaProperty != null)
                {
                    if (KrajTerminaProperty < PocetakTerminaProperty)
                    {
                        results.Add(new ValidationResult("Kraj termina ne sme biti pre pocetka termina"));
                    }
                }
                return results;
            }
        }

        #endregion
    }
}