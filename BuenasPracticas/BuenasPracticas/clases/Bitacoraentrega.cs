using BuenasPracticas.DTO;
using BuenasPracticas.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BuenasPracticas.clases
{
    public class Bitacoraentrega : IBitacora
    {
        string cPaqueteria;
        string cTipotiempo;
        public Bitacoraentrega(string _cPaqueteria,string _cTipotiempo)
        {
            cPaqueteria = _cPaqueteria;
            cTipotiempo = _cTipotiempo;
        }

        public void CrearEstructura()
        {
            string cruta = AppDomain.CurrentDomain.BaseDirectory + "../../../../" + cPaqueteria + "/" + "Entrega";


            if (!Directory.Exists(cruta))
            {
                Directory.CreateDirectory(cruta);
            }
            cruta += "/" + cTipotiempo + ".txt";

            if (File.Exists(cruta))
            {
                File.Delete(cruta);
            }

            File.CreateText(cruta);
        }

        public void GenerarRegistro(string cMensaje)
        {
            string cruta = AppDomain.CurrentDomain.BaseDirectory + "../../../../" + cPaqueteria + "/" + "Entrega" + "/" + cTipotiempo + ".txt";

            using (StreamWriter sw = File.AppendText(cruta))
            {
                sw.WriteLine(cMensaje);
                sw.WriteLine("");
                sw.Close();
            }

        }
        
    }
}
