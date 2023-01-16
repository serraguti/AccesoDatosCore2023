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
