using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPrestamo.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Prestamo> Prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = TERMINAL-C11\SQLEXPRESS; Database = PrestamoDb; Trusted_Connection = True");
        }
    }



}
