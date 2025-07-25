using Microsoft.AspNetCore.Mvc;
using SistemaTareas.ApiConsumer;
using SistemaTareas.model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaTareas.MVC.Controllers
{
    public class ProyectosController : Controller
    {
        public ActionResult Index()
        {
       
            var originalEndpoint = Crud<Proyecto>.GetAll();
            return View(originalEndpoint);

        }
       
        public ActionResult Details(int id)
        {
           
            
            var Tarea = Crud<Proyecto>.GetById(id);
            return View(Tarea);

        }
        public ActionResult Create()
        {
      
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Proyecto data)
        {
          
            try
            {
                Crud<Proyecto>.Create(data);
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

        

            var data = Crud<Proyecto>.GetById(id);
            return View(data);


        }
        // POST: Songs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Proyecto data)
        {

            try
            {
                Crud<Proyecto>.Update(id, data);
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
        
            var data = Crud<Proyecto>.GetById(id);
            return View(data);
        }
        public ActionResult Delete(int id, Proyecto data)
        {
            
            try
            {
                Crud<Proyecto>.Delete(id);
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
