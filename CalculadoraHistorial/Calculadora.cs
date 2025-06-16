namespace EspacioCalculadora
{
    public enum TipoOperacion {
        Suma,
        Resta,
        Multiplicacion,
        Division,
        Limpiar // Representa la acción de borrar el resultado actual o el historial
    }

    public class Calculadora
    {
        private double dato;
        private List<Operacion> historial;

        public Calculadora()
        {
            dato = 0;
            historial = new List<Operacion>();
        }

        public double Resultado
        {
            get => dato;
        }

        public void Sumar(double termino)
        {
            AgregarOperacion(termino, TipoOperacion.Suma);
        }

        public void Restar(double termino)
        {
            AgregarOperacion(termino, TipoOperacion.Resta);
        }

        public void Multiplicar(double termino)
        {
            AgregarOperacion(termino, TipoOperacion.Multiplicacion);
        }

        public void Dividir(double termino)
        {
            if (termino != 0)
            {
                AgregarOperacion(termino, TipoOperacion.Division);
            }
        }

        public void Limpiar()
        {
            historial.Add(new Operacion(dato, 0, TipoOperacion.Limpiar));
            dato = 0;
        }

        private void AgregarOperacion(double valor, TipoOperacion tipo)
        {
            Operacion op = new Operacion(dato, valor, tipo);
            dato = op.Resultado;
            historial.Add(op);
        }

        public List<Operacion> ObtenerHistorial()
        {
            return historial;
        }
    }
}