using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SeedDemo.Models
{
    public class ProfileContext : DbContext
    {
        public ProfileContext() : base("ProfileDatabase")
        {
            //Calling Custom DB Initializer
            Database.SetInitializer<ProfileContext>(new ProfileInitializer<ProfileContext>());
        }

        public DbSet<Profile> prfl { get; set; }

        //Creating Custom DB Initializer
        private class ProfileInitializer<T> : DropCreateDatabaseIfModelChanges<ProfileContext>
        {
            protected override void Seed(ProfileContext context)
            {
                IList<Profile> list = new List<Profile>();
                //Adding Row
                list.Add(new Profile() { Name = "Mathew", Age = 23, MobNo = "0987654321" });
                list.Add(new Profile() { Name = "Steven", Age = 33, MobNo = "2345654321" });

                foreach (Profile pf in list)
                    context.prfl.Add(pf);

                base.Seed(context);
            }
        }
    }
}

