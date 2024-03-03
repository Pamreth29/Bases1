using Microsoft.AspNetCore.Mvc;
using CRUD_TAREA1_FELIXMENDEZ_PAMELAMORATAYA.Datos;
using CRUD_TAREA1_FELIXMENDEZ_PAMELAMORATAYA.Models;


namespace CRUD_TAREA1_FELIXMENDEZ_PAMELAMORATAYA.Controllers
{
    public class MantenedorController : Controller
    {
        EmpleadoDatos _EmpleadoDatos = new EmpleadoDatos();
        public IActionResult Listar()
        {
            //La vista mostrara una lista de empleados
            var objectLista = _EmpleadoDatos.Listar();
            return View(objectLista);
        }

        public IActionResult Guardar()
        {
            //metodo que solo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(EmpleadoModel objectEmpleado)
        {
            //metodo que recibe el objeto para guardarlo en la base de datos
            if (!ModelState.IsValid)
                return View();

            var respuesta = _EmpleadoDatos.Guardar(objectEmpleado);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Modificar(int ID_Empleado)
        {
            //metodo que solo devuelve la vista
            var objectEmpleado = _EmpleadoDatos.Obtener(ID_Empleado);
            return View(objectEmpleado);
        }

        [HttpPost]
        public IActionResult Modificar(EmpleadoModel objectEmpleado)
        {
            //metodo que recibe el objeto para editarlo en la base de datos
            if (!ModelState.IsValid)
                return View();

            var respuesta = _EmpleadoDatos.Modificar(objectEmpleado);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int ID_Empleado)
        {
            //metodo que solo devuelve la vista
            var objectEmpleado = _EmpleadoDatos.Obtener(ID_Empleado);
            return View(objectEmpleado);
        }

        [HttpPost]
        public IActionResult Eliminar(EmpleadoModel objectEmpleado)
        {
            //metodo que recibe el objeto para eliminarlo en la base de datos
            var respuesta = _EmpleadoDatos.Eliminar(objectEmpleado.id);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
