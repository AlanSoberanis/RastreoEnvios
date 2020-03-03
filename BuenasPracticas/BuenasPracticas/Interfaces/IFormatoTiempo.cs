namespace BuenasPracticas.Interfaces
{
    public interface IFormatoTiempo
    {
        string ObtenerFormatoTiempo(decimal _dTiempos);
        void Siguiente(IFormatoTiempo _formatoTiempo);
        
    }
}
