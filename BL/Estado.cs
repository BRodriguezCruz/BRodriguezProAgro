using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public int? IdEstado { get; set; }
        public string? NombreEstado  { get; set; }
        public List<object>? ListaEstados  { get; set; }



        // METHODS
        public static List<Estado> GetAll()
        {
            List<Estado> estados = new List<Estado>();

            try
            {
                using (DL.BrodriguezProAgroContext context = new DL.BrodriguezProAgroContext())
                {
                    var query = context.Estados.FromSqlRaw($"EstadoGetAll").ToList();

                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            Estado estado = new Estado();   

                            estado.IdEstado = registro.IdEstado;
                            estado.NombreEstado = registro.NombreEstado;

                            estados.Add(estado);
                        }
                    }
                    else
                    {
                        string variable = "Fallo en la consulta";
                    }
                }

            }
            catch (Exception ex)
            { 
            var excepcion = ex;
            }
            return estados;
        }
        
    }
}
