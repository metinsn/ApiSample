namespace Entity.DBContext
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class ApiDBContext : DbContext
    {
        public ApiDBContext() : base("name=ApiDB")
        {
            Database.SetInitializer(new ApiCreate());
        }

        public virtual DbSet<User> Users { get; set; }
    }

    public class ApiCreate : CreateDatabaseIfNotExists<ApiDBContext>
    {
        protected override void Seed(ApiDBContext context)
        {
            context.Users.Add(new User()
            {
                FirstName = "Yavuz",
                LastName = "Gedik"
            });

            context.Users.AddRange(new List<User>()
            {
                new User() { FirstName = "Ufuk", LastName = "D�ndar" },
                new User() { FirstName = "�zg�r Do�u", LastName = "Saymaz" },
                new User() { FirstName = "Egehan", LastName = "�afak" },
                new User() { FirstName = "Erdem", LastName = "Fidanboylu" },
                new User() { FirstName = "Se�kin", LastName = "Umur" },
                new User() { FirstName = "Kaan", LastName = "Tanzan" },
                new User() { FirstName = "Esranur", LastName = "Yenice" },
                new User() { FirstName = "Halil", LastName = "Bay�r" }
            });

            context.SaveChanges();
        }
    }
}