using BuenasPracticas.clases;
using BuenasPracticas.DTO;
using BuenasPracticas.Factory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BuenasPracticas
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            List<SolicitudEnvio> LstSolicitudes = new List<SolicitudEnvio>();
            IFormatProvider culture = new CultureInfo("ES-MX", true);

            Configuraciones configuraciones = new Configuraciones();
            ConfiguracionesDTO Configuracion = configuraciones.ObtenerConfiguraciones();
            configuraciones.Bitacora();
            string Comando = string.Empty;
            do
            {
                Console.WriteLine("Seleccione el origen de los envíos:");
                Comando = Console.ReadLine();
                try
                {
                    AdaptadorLectura Adaptador = new AdaptadorLectura(Comando, culture);
                    Adaptador.ObtenerPaquetes(ref LstSolicitudes);
                }
                catch(Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                    Comando = string.Empty;
                }

            }
            while (Comando == string.Empty);

            
            foreach (SolicitudEnvio solicitud in LstSolicitudes)
            {
                try
                {
                    FactoryEnvios factoryEnvios = new FactoryEnvios(solicitud, Configuracion);
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
            Console.WriteLine("finalizado...");
            Console.ReadKey();
        }


        
    }
}

    
