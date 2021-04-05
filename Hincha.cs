namespace Olimpia
{
    [System.Serializable()]
    public class Hincha
    {
        public enum TipoDocumentoId : ushort
        {
            Cedula = 0,
            TarjetaIdentidad = 1,
            Cedulaextranjeria = 2,
            Pasaporte = 3
        }
        public enum TGenero : ushort
        {
            Masculino = 0,
            Femenino = 1,
            Otro = 2
        }
        public string NumID { get; set; }
        public TipoDocumentoId TipoID { get; set; }
        public string Nombre { get; set; }
        public ulong Telefono { get; set; }
        public TGenero Genero { get; set; }
        public string EMail { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
    }
}
