using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Georreferencia
    {
        // PROPERTIES INSTEAD ML
        public int IdGeorreferencia { get; set; }
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }
        public Estado? Estado { get; set; }
        public List<object>? ListaGeorreferencias { get; set; }
        public bool Correct { get; set; }


        // METHODS 

        public static Georreferencia GetAll()
        {
            Georreferencia georreferencia = new Georreferencia();
            try
            {
                using (DL.BrodriguezProAgroContext context = new DL.BrodriguezProAgroContext())
                {
                    var query = context.Georreferencia.FromSqlRaw($"GeorreferenciaGetAll").ToList();

                    georreferencia.ListaGeorreferencias = new List<object>();

                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            Georreferencia georreferencia1 = new Georreferencia();  

                            georreferencia1.IdGeorreferencia = registro.IdGeorreferencia;
                            georreferencia1.Latitud = registro.Latitud;
                            georreferencia1.Longitud = registro.Longitud;
                            georreferencia.Estado = new Estado();
                            georreferencia1.Estado.IdEstado = registro.IdEstado;

                            georreferencia.ListaGeorreferencias.Add(georreferencia1);
                            georreferencia.Correct = true;
                        }
                    }
                    else
                    {
                        georreferencia.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                var excepcion = ex;
                georreferencia.Correct = false;
            }
            return georreferencia;
        }

    }
}