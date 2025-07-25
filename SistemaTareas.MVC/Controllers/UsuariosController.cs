using Microsoft.AspNetCore.Mvc;
using SistemaTareas.ApiConsumer;
using SistemaTareas.model;

namespace SistemaTareas.MVC.Controllers
{
    public class UsuariosController : Controller
    {
        public ActionResult Index()
        {

            var originalEndpoint = Crud<Usuario>.GetAll();
            return View(originalEndpoint);

        }
        public ActionResult Details(int id)
        {

            var Tarea = Crud<Usuario>.GetById(id);
            return View(Tarea);

        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario data)
        {
            try
            {
                Crud<Usuario>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: Songs/Edit/5
        public ActionResult Edit(int id)
        {


            var data = Crud<Usuario>.GetById(id);
            return View(data);


        }
        // POST: Songs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario data)
        {

            try
            {
                Crud<Usuario>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }

        }
        public ActionResult Delete(int id)
        {

            var data = Crud<Usuario>.GetById(id);
            return View(data);
        }
        public ActionResult Delete(int id, Usuario data)
        {
            try
            {
                Crud<Usuario>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }
    }

}
