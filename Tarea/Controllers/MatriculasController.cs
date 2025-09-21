using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Tarea.Models;

namespace Tarea.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MatriculasController : ControllerBase
    {
        //Lista de Matriculas vacia
        private static List<Matricula> Matriculas;


        //constructor por defecto
        public MatriculasController()
        {
            if (Matriculas == null) {
                Matriculas = new List<Matricula>(); }

        }

        //metodo GET
        [HttpGet]
        [Route("getMatricula")]
        public List<Matricula> Get() 
        {
            
            return Matriculas;   
        }

        [HttpGet]
        [Route("getPago")]
        public string GetPago(int num)
        {
            string msj = "No se pudo calcular el total";
            foreach (var item in Matriculas) {
                if (item.NumMatricula == num) {
                    double pagoTotal = item.MontoPago - (item.MontoPago * item.Descuento);
                    msj = $"El monto total a pagar es {pagoTotal}";
                }
            }
            return msj;
            
        }

        [HttpPut]
        [Route("Add")]
        public string Add(Matricula matricula) 
        {
            string msj = "Error al añadir";
            try
            {
                Matriculas.Add(matricula);
                msj = "Matrula añadida";
            } catch(Exception ex)
            {
                msj = ex.Message;
            }
            return msj;
        }

        [HttpDelete]
        [Route("delete")]
        public string Delete(int NumMatricula) {

            string msj = "Error al eliminar";
            try
            {
                foreach(var temp in Matriculas)
                {
                    if (temp.NumMatricula == NumMatricula)
                    {
                        Matriculas.Remove(temp);
                        msj = "Matricula eliminada";
                    }
                }
            } catch(Exception ex)
            {
                msj = ex.Message;
            }

            return msj;
        }

        [HttpPost]
        [Route("Update")]
        public string update(Matricula mat)
        {
            string msj = "Error al actualizar";
            try
            {
                var pMat = Matriculas.FirstOrDefault(r => r.NumMatricula == mat.NumMatricula);
                if (pMat != null)
                {
                    ;
                    Matriculas.Remove(pMat);
                    Matriculas.Add(mat);
                    msj = "Matricula actualizado";
                }
            }
            catch (Exception ex) {
            
                msj =ex.Message;
            }

            return msj;

        }







    }
}
