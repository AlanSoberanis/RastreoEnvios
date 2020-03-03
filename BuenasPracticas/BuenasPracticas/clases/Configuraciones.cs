using BuenasPracticas.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace BuenasPracticas.clases
{
    public class Configuraciones
    {

        public ConfiguracionesDTO ObtenerConfiguraciones()
        {
            StreamReader reader = new StreamReader(File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "../../Config.json"));



            var cEnvios = reader.ReadToEnd();
            //JObject parsed = JObject.Parse(cEnvios);
            //var JSonPedidos = parsed["Pedidos"];
            ConfiguracionesDTO Configuracion = new ConfiguracionesDTO();

            //foreach (var Envio in JSonPedidos)
            //{
               

               
                
            //}

            return Configuracion;
        }

        public void Bitacora()
        {
            Bitacoraentrega bitacoraentrega;
            BitacoraPendiente bitacoraPendiente;
            List<string> lstTiempos = new List<string>() { "Minutos", "Horas", "Día", "Semanas", "Meses", "Bimestres", "Años" };
            List<string> lstPAqueterias = new List<string>()
            { "Estafeta","Fedex","DHL"};

            foreach (string cPaqueteria in lstPAqueterias)
            {
                foreach (string cTiempos in lstTiempos)
                {
                    bitacoraentrega = new Bitacoraentrega(cPaqueteria,cTiempos);
                    bitacoraPendiente = new BitacoraPendiente(cPaqueteria, cTiempos);
                    bitacoraPendiente.CrearEstructura();
                    bitacoraentrega.CrearEstructura();
                }
            }

        }
        
    }
}
