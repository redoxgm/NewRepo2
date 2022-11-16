using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace tpLabo4_usarEste_.Models
{
    public class AppDbContext :IdentityDbContext
    {
      

        public AppDbContext(DbContextOptions<AppDbContext> options)

            : base(options)
        {

        }
        

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
           

        //}

        public DbSet<Celular> Celular { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<SistemaOperativo> SistemaOperativo { get; set; }

        public  DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<TiendaWEb> TiendaWEbs { get; set; }




    }
}






    

       






        





    

   


