using BuenasPracticas.clases;
using BuenasPracticas.DTO;
using BuenasPracticas.Factory;
using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace BuenasPracticas
{
    internal class Program
    {

        static void Main(string[] args)
        {
            decimal dDistancia = 0;
            string cFechaPedido = string.Empty;
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            StreamReader reader = new StreamReader(File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "../../Envios.csv"),Encoding.GetEncoding("windows-1254"),true);

            while (!reader.EndOfStream)
            {
                try
                {
                    var cEnvios = reader.ReadLine().Split(',');


                    SolicitudEnvio solicitud = new SolicitudEnvio();

                    dDistancia = 0;
                    solicitud.cPaqueteria = cEnvios[1];
                    solicitud.cTransporte = cEnvios[2];
                    cFechaPedido = cEnvios[3];
                    solicitud.dtFechaEnvio = DateTime.ParseExact(cFechaPedido, "dd/MM/yyyy HH:mm", culture);
                    solicitud.cPaísOrigen = cEnvios[4];
                    solicitud.cCiudadOrigen = cEnvios[5];
                    solicitud.cPaísDestino = cEnvios[6];
                    solicitud.cCiudadDestino = cEnvios[7];
                    solicitud.dtFechaActual = DateTime.Now;
                    if (!decimal.TryParse(cEnvios[0], out dDistancia))
                        dDistancia = 0;

                    solicitud.dDistancia = dDistancia;

                    FactoryEnvios factoryEnvios = new FactoryEnvios(solicitud);
                    IEnviosPaquetes Envio = factoryEnvios.CrearEnvio();

                    Console.WriteLine(Envio.ProcesarEnvios());
                    Console.WriteLine("");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Continuar...");
            Console.ReadKey();
        }

    }
}

    
