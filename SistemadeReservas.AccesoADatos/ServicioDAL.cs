﻿using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeReservas.AccesoADatos
{
    public class ServicioDAL
    {
        public static async Task<int> CrearAsync(ServicioDAL pServicio)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pServicio);
                result = await bdContexto.SaveChangesAsync();

            }

            return result;
        }
        public static async Task<int> ModificarAsync(ServicioDAL pServicio)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var servicio = await bdContexto.Servicio.FirstOrDefaultAsync(s => s.Id == pServicio.Id);
                servicio.Nombre = pServicio.Nombre;
                servicio.Estado = pServicio.Estado;
                bdContexto.Update(servicio);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(ServicioDAL pServicio)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var servicio = await bdContexto.Servicio.FirstOrDefaultAsync(s => s.Id == pServicio.Id);
                bdContexto.Servicio.Remove(servicio);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Servicio> ObtenerPorIdAsync(ServicioDAL pServicio)
        {
            var servicio = new Servicio();
            using (var bdContexto = new BDContexto())
            {
                servicio = await bdContexto.Servicio.FirstOrDefaultAsync(s => s.Id == pServicio.Id);
            }
            return servicio;
        }
        public static async Task<List<Servicio>> ObtenerTodosAsync()
        {
            var servicios = new List<Servicio>();
            using (var bdContexto = new BDContexto())
            {
                servicios = await bdContexto.Servicio.ToListAsync();
            }
            return servicios;
        }
        internal static IQueryable<Servicio> QuerySelect(IQueryable<Servicio> pQuery, Servicio pServicio)
        {
            if (pServicio.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pServicio.Id);

            if (!string.IsNullOrWhiteSpace(pServicio.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pServicio.Nombre));

            if (pServicio.Estado > 0)
                pQuery = pQuery.Where(s => s.Id == pServicio.Estado);

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pServicio.Top_Aux > 0)
                pQuery = pQuery.Take(pServicio.Top_Aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Servicio>> BuscarAsync(Servicio pServicio)
        {
            var servicios = new List<Servicio>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Servicio.AsQueryable();
                select = QuerySelect(select, pServicio);
                servicios = await select.ToListAsync();
            }
            return servicios;
        }
    }

}
