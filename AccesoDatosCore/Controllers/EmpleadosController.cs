using AccesoDatosCore.Models;
using AccesoDatosCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace AccesoDatosCore.Controllers
{
    public class EmpleadosController : Controller
    {
        RepositoryEmpleados repo;

        //EN EL CONSTRUCTOR, RECIBIMOS EL REPOSITORIO
        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        public IActionResult Details(int idempleado)
        {
            Empleado empleado = this.repo.FindEmpleado(idempleado);
            return View(empleado);
        }

        public IActionResult EmpleadosSalario()
        {
            //TENDRIAMOS QUE ENVIAR LA COLECCION DE "SALARIOS"
            //A LA VISTA
            List<int> salarios = new List<int> { 500000, 250000, 30000, 125000, 390000 };
            ViewData["SALARIOS"] = salarios;
            //UTILIZAMOS EL REPOSITORY DE EMPLEADOS
            List<Empleado> empleados = repo.GetEmpleados();
            return View(empleados);
        }

        //NECESITAMOS UN POST PARA CUANDO BUSQUEMOS EMPLEADOS
        [HttpPost]
        public IActionResult EmpleadosSalario(int salario)
        {
            List<Empleado> empleados = repo.GetEmpleadosSalario(salario);
            return View(empleados);
        }

        public IActionResult Index()
        {
            List<Empleado> empleados = this.repo.GetEmpleados();
            return View(empleados);
        }
    }
}
