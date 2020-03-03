using BuenasPracticas.Interfaces;
using System;

namespace BuenasPracticas.clases
{
    public class ErrorMensaje : IMensajesColor
    {
        public ErrorMensaje()
        {
            AsignarColores();
        }

        public void AsignarColores()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public string ImprimirMensajeEnvio()
        {
            return "{0}";
        }
    }
}