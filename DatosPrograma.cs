namespace Olimpia
{
    public static class DatosPrograma
    {
        public static event System.EventHandler OnChange;
        private static int _Capacidad = 0;
        private static float _Aforo = 0;

        public static int Capacidad
        {
            get { return _Capacidad; }   // get method
            set {
                _Capacidad = value;
                OnChange?.Invoke(null, null);
            }  // set method
        }

        public static float Aforo
        {
            get { return _Aforo; }   // get method
            set {
                _Aforo = value;
                OnChange?.Invoke(null, null);
            }  // set method
        }

        public static EvList<Hincha> HinchasEnum { get; set; }

        public static EvList<Visitante> VisitantesEnum { get; set; }
    }

    [System.Serializable]
    public class _DatosPrograma
    {
        public int Capacidad { get; set; }
        public float Aforo { get; set; }
        public EvList<Hincha> HinchasEnum { get; set; }
        public EvList<Visitante> VisitantesEnum { get; set; }
    }
}