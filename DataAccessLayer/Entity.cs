using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Entity
    {
        private DefaultConnection _context;

        public Entity()
        {
            this._context = new DefaultConnection();
        }

        public void Insert(string tableName, string values)
        {
            this._context.Database.ExecuteSqlCommand($"INSERT INTO {tableName} VALUES ({values})");
        }

        public dynamic Get(object objectForGet, DateTime? pocetakTermina = null, DateTime? krajTermina = null)
        {
            if (objectForGet is Sto)
            {
                return this._context.Stoes.ToList();
            }


            if (objectForGet is Rezervacija)
            {
                if (pocetakTermina == null || krajTermina == null)
                {
                    return this._context.Rezervacijas.ToList();
                }
                else
                {
                    return this._context.Rezervacijas.ToList();
                }
            }
            return null;
        }
    }
}
