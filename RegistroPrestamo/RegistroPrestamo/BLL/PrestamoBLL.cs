using Microsoft.EntityFrameworkCore;
using RegistroPrestamo.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPrestamo.BLL
{
    class PrestamoBLL
    {
        public static bool Calcular(Prestamo prestamo)
        {
            bool paso = false;

            Contexto db = new Contexto();

            try
            {
                if (db.Prestamos.Add(prestamo) != null)
                    paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;

        }

        public static bool Modificar(Prestamo prestamo)
        {
            bool paso = false;

            Contexto db = new Contexto();

            try
            {
                db.Entry(prestamo).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;

        }


        public static Prestamo Buscar(int id)
        {
            
            Contexto db = new Contexto();
            Prestamo prestamo = new Prestamo();


            try
            {
                prestamo = db.Prestamos.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return prestamo;

        }
    }
}
