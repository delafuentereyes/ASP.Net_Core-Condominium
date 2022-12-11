using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_BD.DatabaseHelper;
using System.Data.SqlClient;
using System.Data;
using Proyecto_BD2.Models;

namespace Proyecto_BD2.Controllers
{
    public class HousingController : Controller
    {
        // GET: CreatePHController

		public ActionResult GetHousing(int id_Habitacional)
		{

			List<Housing> housings = new List<Housing>();
			foreach (DataRow item in DatabaseHelper.ExecuteStoreProcedure("spGetPH", new List<SqlParameter> { new SqlParameter("@id_Habitacional", id_Habitacional) }).Rows)
			{
				housings.Add(new Housing
				{
					Logo_Habitacional = item["Logo_Habitacional"].ToString(),
					Codigo_Habitacional = item["Codigo_Habitacional"].ToString(),
					Nombre_Habitacional = item["Nombre_Habitacional"].ToString(),
					Direccion_Habitacional = item["Direccion_Habitacional"].ToString(),
					Telefono_Oficina = item["Telefono_Oficina"].ToString(),
				});
			}

			ViewBag.Housing = housings;

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
