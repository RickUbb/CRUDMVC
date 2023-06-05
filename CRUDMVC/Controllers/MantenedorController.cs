using Microsoft.AspNetCore.Mvc;

using CRUDMVC.Datos;
using CRUDMVC.Models;

namespace CRUDMVC.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();

        public IActionResult Listar()
        {
            // Mostrara un lista de contactos
            var oLista = _ContactoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            // Devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //Recibe el objeto y lo guarda en la BDD
            if (!ModelState.IsValid)
            {   
                return View();
            }
            var respuesta = _ContactoDatos.Guardar(oContacto);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            } 
            else
            {
                return View();
            }
            
        }

        public IActionResult Editar(int IdContacto)
        {
            // Devuelve la vista
            var oContacto = _ContactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            //Recibe el objeto y lo guarda en la BDD
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _ContactoDatos.Editar(oContacto);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int IdContacto)
        {
            // Devuelve la vista
            var oContacto = _ContactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {
            //Recibe el objeto y lo elimina de la BDD
            var respuesta = _ContactoDatos.Eliminar(oContacto.IdContacto);
            if (respuesta)
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
