using Microsoft.AspNetCore.Mvc;
using MantenedorVehiculos.Data;
using MantenedorVehiculos.Models;

namespace MantenedorVehiculos.Controllers
{
    public class MantenedorController : Controller
    {
        DatosVehiculo _datosVehiculo = new DatosVehiculo(); 
        public IActionResult Listar()
        {
            var oListaVehiculos = _datosVehiculo.ListarDatos();
            return View(oListaVehiculos);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ModeloVehiculos oVehiculo)
        {
            if (!ModelState.IsValid)
                return View();

            var guardado = _datosVehiculo.Guardar(oVehiculo);
            if (guardado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int idVehiculo)
        {
            var oVehiculo = _datosVehiculo.ObtenerId(idVehiculo);
            return View(oVehiculo);
        }

        [HttpPost]
        public IActionResult Editar(ModeloVehiculos oVehiculo)
        {
            if (!ModelState.IsValid)
                return View();

            var editado = _datosVehiculo.Editar(oVehiculo);
            if (editado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int idVehiculo)
        {
            var oVehiculo = _datosVehiculo.ObtenerId(idVehiculo);
            return View(oVehiculo);
        }

        [HttpPost]
        public IActionResult Eliminar(ModeloVehiculos oVehiculo)
        {
            var eliminado = _datosVehiculo.Eliminar(oVehiculo.Id);
            if (eliminado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
