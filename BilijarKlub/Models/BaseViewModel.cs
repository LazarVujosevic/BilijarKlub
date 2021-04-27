using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilijarKlub.Models
{
    public class BaseViewModel
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public List<string> ValidationRulesMessages { get; set; }

        public BaseViewModel()
        {
            this.ValidationRulesMessages = new List<string>();
        }
    }
}