using Microsoft.AspNetCore.Mvc;
using SistemaTareas.ApiConsumer;
using SistemaTareas.model;

namespace SistemaTareas.MVC.Controllers
{
    public class AsignacionesProyectosController : Controller
    {
        public ActionResult Index()
        {

            var originalEndpoint = Crud<AsignacionProyecto>.GetAll();
            return View(originalEndpoint);

        }
        public ActionResult Details(int id)
        {

            var Tarea = Crud<AsignacionProyecto>.GetById(id);
            return View(Tarea);

        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AsignacionProyecto data)
        {
            try
            {
                Crud<AsignacionProyecto>.Create(data);
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


            var data = Crud<AsignacionProyecto>.GetById(id);
            return View(data);


        }
        // POST: Songs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AsignacionProyecto data)
        {

            try
            {
                Crud<AsignacionProyecto>.Update(id, data);
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

            var data = Crud<AsignacionProyecto>.GetById(id);
            return View(data);
        }
        public ActionResult Delete(int id, AsignacionProyecto data)
        {
            try
            {
                Crud<AsignacionProyecto>.Delete(id);
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
