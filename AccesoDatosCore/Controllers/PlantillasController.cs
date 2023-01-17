using AccesoDatosCore.Models;
using AccesoDatosCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AccesoDatosCore.Controllers
{
    public class PlantillasController : Controller
    {
        RepositoryPlantilla repo;

        public PlantillasController(RepositoryPlantilla repo)
        {
            this.repo = repo;
        }

        public IActionResult IncrementarSalarioFunciones()
        {
            List<string> funciones = this.repo.GetFunciones();
            ViewData["FUNCIONES"] = funciones;
            return View();
        }

        [HttpPost]
        public IActionResult IncrementarSalarioFunciones(string funcion, int incremento)
        {
            int modificados = this.repo.IncrementarSalariosFunciones(funcion, incremento);
            List<string> funciones = this.repo.GetFunciones();
            ViewData["FUNCIONES"] = funciones;
            ViewData["MENSAJE"] = "Empleados modificados: " + modificados;
            List<Plantilla> personas = this.repo.GetPlantillaFuncion(funcion);
            return View(personas);
        }

        public IActionResult Index()
        {
            List<Plantilla> plantilla = this.repo.GetPlantilla();
            return View(plantilla);
        }

        [HttpPost]
        public IActionResult Index(string funcion)
        {
            List<Plantilla> plantilla = this.repo.GetPlantillaFuncion(funcion);
            //SI NO HAY EMPLEADOS DE LA PLANTILLA
            if (plantilla.Count == 0)
            {
                //NO LE DEVOLVEMOS DATOS
                return View();
            }
            else
            {
                return View(plantilla);
            }
        }
    }
}
