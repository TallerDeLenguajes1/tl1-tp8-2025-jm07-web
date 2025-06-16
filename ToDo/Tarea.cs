namespace EspacioTarea
{
    public class Tarea
    {
        public int TareaID { get; set; }
        public string Descripcion { get; set; }
        public int Duracion { get; set; } // Validar que esté entre 10 y 100
                                          // Puedes añadir un constructor y métodos auxiliares si lo consideras necesario
        public Tarea(int TareaID, string Descripcion, int Duracion)
        {
            this.TareaID = TareaID;
            this.Descripcion = Descripcion;
            this.Duracion = Duracion;
        }

        public void Mostrar()
        {
            Console.WriteLine($"ID: {TareaID}, Descripción: {Descripcion}, Duración: {Duracion} minutos");
        }
    }
}