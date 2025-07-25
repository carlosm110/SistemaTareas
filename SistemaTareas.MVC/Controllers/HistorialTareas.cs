using Microsoft.AspNetCore.Mvc;
using SistemaTareas.ApiConsumer;
using SistemaTareas.model;

namespace SistemaTareas.MVC.Controllers
{
    public class HistorialTareas : Controller
    {
        public ActionResult Index()
        {

            var originalEndpoint = Crud<HistorialTarea>.GetAll();
            return View(originalEndpoint);

        }
        public ActionResult Details(int id)
        {

            var Tarea = Crud<HistorialTarea>.GetById(id);
            return View(Tarea);

        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HistorialTarea data)
        {
            try
            {
                Crud<HistorialTarea>.Create(data);
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


            var data = Crud<HistorialTarea>.GetById(id);
            return View(data);


        }
        // POST: Songs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HistorialTarea data)
        {

            try
            {
                Crud<HistorialTarea>.Update(id, data);
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

            var data = Crud<HistorialTarea>.GetById(id);
            return View(data);
        }
        public ActionResult Delete(int id, HistorialTarea data)
        {
            try
            {
                Crud<HistorialTarea>.Delete(id);
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
