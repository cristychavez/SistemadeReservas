using Microsoft.EntityFrameworkCore;
using SistemadeReservas.EntiadadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemadeReservas.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public object Servicio { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-MMB6RRI; Initial Catalog=SistemadeReservas;Integrated Security=True");
            //optionsBuilder.UseSqlServer(@"Data Source=deptosDB.mssql.somee.com; Initial Catalog=deptosDB; User Id=deptosProject; Pwd=admin2022");
        }
    }
}
