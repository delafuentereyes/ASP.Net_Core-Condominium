using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_BD2.Controllers
{
    public class CreatePHController : Controller
    {
        // GET: CreatePHController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CreatePHController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CreatePHController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreatePHController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CreatePHController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CreatePHController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CreatePHController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CreatePHController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
