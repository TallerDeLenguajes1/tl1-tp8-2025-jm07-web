using EspacioCalculadora;

Calculadora calc = new Calculadora();

int continuar = 1, op;
double num;
string StringOp;

while (continuar != 0)
{
    Console.WriteLine("Menú:");
    Console.WriteLine("1.Sumar | 2.Restar | 3.Multiplicar | 4.Dividir | 5.Limpiar calculadora | 6.Ver historial");

    do
    {
        Console.WriteLine("Ingrese el número de la operación: ");
        StringOp = Console.ReadLine();
        int.TryParse(StringOp, out op);
    } while (op < 1 || op > 6);

    if (op != 5 && op != 6)
    {
        Console.WriteLine("Ingrese un numero: ");
        while (!double.TryParse(Console.ReadLine(), out num))
        {
            Console.WriteLine("Ingrese un número valido.");
        }

        switch (op)
        {
            case 1:
                calc.Sumar(num);
                Console.WriteLine("El valor actual de la calculadora es: " + calc.Resultado);
                break;
            case 2:
                calc.Restar(num);
                Console.WriteLine("El valor actual de la calculadora es: " + calc.Resultado);
                break;
            case 3:
                calc.Multiplicar(num);
                Console.WriteLine("El valor actual de la calculadora es: " + calc.Resultado);
                break;
            case 4:
                if (num != 0)
                {
                    calc.Dividir(num);
                    Console.WriteLine("El valor actual de la calculadora es: " + calc.Resultado);
                }
                break;
            default:
                Console.WriteLine("Numero de operación no enconontrado.");
                break;
        }
    } 
    else if (op == 5)
    {
        calc.Limpiar();
        Console.WriteLine("El valor actual de la calculadora es: " + calc.Resultado);
    }
    else
    {
        Console.WriteLine("Historial de operaciones: ");
        foreach (var operacion in calc.ObtenerHistorial())
        {
            string simbolo = "";
            switch (operacion.Tipo)
            {
                case TipoOperacion.Suma:
                    simbolo = "+";
                    break;
                case TipoOperacion.Resta:
                    simbolo = "-";
                    break;
                case TipoOperacion.Multiplicacion:
                    simbolo = "*";
                    break;
                case TipoOperacion.Division:
                    simbolo = "/";
                    break;
                case TipoOperacion.Limpiar:
                    Console.WriteLine($"Limpieza (resultado anterior: {operacion.ResultadoAnterior})");
                    continue;
            }
            Console.WriteLine($"{operacion.ResultadoAnterior} {simbolo} {operacion.NuevoValor} = {operacion.Resultado}");
        }
    }

    do
    {
        Console.WriteLine("¿Desea continuar? (SI = 1, NO = 0); ");
        int.TryParse(Console.ReadLine(), out continuar);
    } while (continuar != 0 && continuar != 1);
}
