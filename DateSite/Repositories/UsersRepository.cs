using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UsersRepository
    {


        /// <summary>
        /// Hämtar alla användare
        /// </summary>
        public List<Profiles> fetchProfiles()
        {
            using (var context = new UserDBEntities())
            {
                context.Database.Connection.Open();
                return context.Profiles.ToList();
            }
        }


        /// <summary>
        /// Lägger till en användare i databasen
        /// </summary>
        public void insertUser(Profiles profile)
        {
            try
            {
                using (var context = new UserDBEntities())
                {
                    context.Database.Connection.Open();
                    context.Profiles.Add(profile);
                    context.SaveChanges();
                }
            }
            catch(Exception e)
            {
                
            }

        }
    }
}
