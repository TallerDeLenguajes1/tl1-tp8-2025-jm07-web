// See https://aka.ms/new-console-template for more information
using EspacioTarea;

int cantidad, id, duracion;
string descripcion, opcion;
bool salir = false;

List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();

Console.WriteLine("Ingrese la cantidad de tareas pendientes: ");
while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
{
    Console.WriteLine("Valor inválido. Ingrese un número mayor a cero:");
}

for (int i = 0; i < cantidad; i++)
{
    Console.WriteLine($"\nTarea {i + 1}");

    Console.Write("Ingrese el ID de la tarea: ");
    while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
    {
        Console.WriteLine("ID inválido. Intente de nuevo:");
    }

    Console.Write("Ingrese la descripción de la tarea: ");
    do
    {
        descripcion = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(descripcion)) {
            Console.WriteLine("Descripción inválida. Intente de nuevo:");
        }
    } while (string.IsNullOrWhiteSpace(descripcion));

    Console.Write("Ingrese la duración (entre 10 y 100): ");
    while (!int.TryParse(Console.ReadLine(), out duracion) || duracion < 10 || duracion > 100)
    {
        Console.WriteLine("Duración inválida. Intente de nuevo:");
    }

    tareasPendientes.Add(new Tarea(id, descripcion, duracion));
}

while (!salir)
{
    Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
    Console.WriteLine("1. Mover tarea a realizadas");
    Console.WriteLine("2. Buscar tarea pendiente por descripción");
    Console.WriteLine("3. Ver tareas pendientes");
    Console.WriteLine("4. Ver tareas realizadas");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opción: ");

    opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            MoverTarea(tareasPendientes, tareasRealizadas);
            break;
        case "2":
            BuscarTarea(tareasPendientes);
            break;
        case "3":
            MostrarTareas(tareasPendientes, "Tareas Pendientes");
            break;
        case "4":
            MostrarTareas(tareasRealizadas, "Tareas Realizadas");
            break;
        case "5":
            salir = true;
            break;
        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
}

// ----------- FUNCIONES AUXILIARES -----------
static void MoverTarea(List<Tarea> pendientes, List<Tarea> realizadas)
{
    Console.WriteLine("\nIngrese el ID de la tarea que desea marcar como realizada:");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        Tarea tarea = pendientes.Find(t => t.TareaID == id);
        if (tarea != null)
        {
            pendientes.Remove(tarea);
            realizadas.Add(tarea);
            Console.WriteLine("Tarea movida correctamente.");
        }
        else
        {
            Console.WriteLine("Tarea no encontrada.");
        }
    }
    else
    {
        Console.WriteLine("ID inválido.");
    }
}

static void BuscarTarea(List<Tarea> pendientes)
{
    Console.WriteLine("\nIngrese una palabra clave para buscar en la descripción:");
    string palabra = Console.ReadLine();
    var resultados = pendientes.FindAll(t => t.Descripcion.Contains(palabra, StringComparison.OrdinalIgnoreCase));
    if (resultados.Count == 0)
    {
        Console.WriteLine("No se encontraron tareas.");
    }
    else
    {
        Console.WriteLine("Tareas encontradas:");
        foreach (var t in resultados)
            t.Mostrar();
    }
}

static void MostrarTareas(List<Tarea> lista, string titulo)
{
    Console.WriteLine($"\n--- {titulo} ---");
    if (lista.Count == 0) {
        Console.WriteLine("No hay tareas.");
    } else
    {
        foreach (var t in lista) {
            t.Mostrar();
        }       
    }      
}