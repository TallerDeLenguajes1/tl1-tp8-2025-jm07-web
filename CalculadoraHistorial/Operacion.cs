namespace EspacioCalculadora
{
    public class Operacion
    {
        private double resultadoAnterior; // Almacena el resultado previo al cálculo actual
        private double nuevoValor; //El valor con el que se opera sobre el resultado anterior
        private TipoOperacion operacion; // El tipo de operación realizada

        public double Resultado {
            /* Lógica para calcular o devolver el resultado */
            get
            {
                switch (operacion)
                {
                    case TipoOperacion.Suma:
                        return resultadoAnterior + nuevoValor;
                    case TipoOperacion.Resta:
                        return resultadoAnterior - nuevoValor;
                    case TipoOperacion.Multiplicacion:
                        return resultadoAnterior * nuevoValor;
                    case TipoOperacion.Division:
                        if (nuevoValor != 0)
                        {
                            return resultadoAnterior / nuevoValor;
                        } else
                        {
                            return 0;
                        }
                    case TipoOperacion.Limpiar:
                        return 0;
                    default:
                        return 0;
                }
            }
        }

        public double ResultadoAnterior
        {
            get {return resultadoAnterior;}
        }

        public TipoOperacion Tipo
        {
            get {return operacion;}
        }
        
        // Propiedad pública para acceder al nuevo valor utilizado en la operación
        public double NuevoValor {
            get {return nuevoValor;}
        }
        
        // Constructor u otros métodos necesarios para inicializar y gestionar la operación
        public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operacion)
        {
            this.resultadoAnterior = resultadoAnterior;
            this.nuevoValor = nuevoValor;
            this.operacion = operacion;
        } 
    }
}