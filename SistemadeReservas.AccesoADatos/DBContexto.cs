﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeReservas.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Nombre> Nombre { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-MMB6RRI; Initial Catalog=SistemadeReservas;Integrated Security=True");
            //optionsBuilder.UseSqlServer(@"Data Source=deptosDB.mssql.somee.com; Initial Catalog=deptosDB; User Id=deptosProject; Pwd=admin2022");
        }
    }
}
