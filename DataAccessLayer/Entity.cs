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

        public dynamic Get(object objectForGet, string whereClause = null)
        {
            if (objectForGet is Sto)
            {
                return this._context.Stoes.Where(x => x.IsDeleted == false).ToList();
            }


            if (objectForGet is Rezervacija)
            {
                return this._context.Rezervacijas.SqlQuery($"SELECT * FROM dbo.[Rezervacija] {whereClause}").ToList();
            }
            return null;
        }
    }
}
