namespace Tarea.Models
{
    public class Matricula
    {
        public int NumMatricula { get; set; }
        public string Carnet {  get; set; }
        public string NombreEstudiante { get; set; }
        public string Curso { get; set; }
        public DateTime FechaPago { get; set; }
        public int MontoPago { get; set; }
        public double Descuento { get; set; }
    }
}
