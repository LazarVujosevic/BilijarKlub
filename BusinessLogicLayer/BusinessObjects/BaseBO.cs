using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BusinessObjects
{
    public class BaseBO
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        protected Entity entity { get; set; }

        public BaseBO()
        {
            this.entity = new Entity();
        }
    }
}
