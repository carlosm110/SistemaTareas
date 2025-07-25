using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaTareas.model;
using SistemaTareas.ApiConsumer;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;

namespace SistemaTareas.MVC.Controllers
{
    public class ComentariosTareasController : Controller
    {
        

        
        public ActionResult Index()
        {
            
            var originalEndpoint = Crud<Tarea>.GetAll();
            return View(originalEndpoint);

        }
       
        public ActionResult Details(int id)
        {
            
            
            var comentarioTarea = Crud<Tarea>.GetById(id);
            return View(comentarioTarea);

        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tarea data)
        {
            try
            {
                Crud<Tarea>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: Songs/Edit/5
        public ActionResult  Edit(int id)
        {


            var data = Crud<Tarea>.GetById(id);
            return View(data);


        }
        // POST: Songs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tarea data)
        {

            try
            {
                Crud<Tarea>.Update(id, data);
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
           
            var data = Crud<Tarea>.GetById(id);
            return View(data);
        }
        public ActionResult Delete(int id, Tarea data)
        {
            try
            {
                Crud<Tarea>.Delete(id);
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