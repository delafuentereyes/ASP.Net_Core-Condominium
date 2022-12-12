using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_BD.DatabaseHelper;
using System.Data.SqlClient;
using System.Data;
using Proyecto_BD2.Models;
using Newtonsoft.Json;

namespace Proyecto_BD2.Controllers
{
	public class HabitacionalesController : Controller
	{
        // GET: CreatePHController

        public ActionResult Index(string busqueda)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("userAccessListSession")))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                
                ViewBag.Habitacional = GetPHs(busqueda);

                return View();
            }
        }

        public List<Habitacional> GetPHs(string busqueda)
        {

            DataTable ds = DatabaseHelper.ExecuteStoreProcedure("spGetPHs", null);
            List<Habitacional> habitacionales = new List<Habitacional>();

            foreach (DataRow row in ds.Rows)
            {
                habitacionales.Add(new Habitacional()
                {
                    Logo_Habitacional = ds.Rows[0]["Logo_Habitacional"].ToString(),
                    Codigo_Habitacional = ds.Rows[0]["Codigo_Habitacional"].ToString(),
                    Nombre_Habitacional = ds.Rows[0]["Nombre_Habitacional"].ToString(),
                    Direccion_Habitacional = ds.Rows[0]["Direccion_Habitacional"].ToString(),
                    Telefono_Oficina = ds.Rows[0]["Telefono_Oficina"].ToString(),
                });
            }

            return habitacionales;
        }

		public ActionResult EditPH(int id_Habitacional)
		{
			if (String.IsNullOrEmpty(HttpContext.Session.GetString("userAccessListSession")))
			{
				return RedirectToAction("Index", "Login");
			}
			else
			{
				ViewBag.habitacional = GetPH(id_Habitacional);

				ViewBag.viviendas = ViviendasController.CargarViviendas(idProyectoHabitacional);
				return View();
			}
		}

        public List<Habitacional> GetPH(string id_Habitacional)
        {
			List<Habitacional> habitacionales = new List<Habitacional>();

			DataTable ds = DatabaseHelper.ExecuteStoreProcedure("spGetPH", new List<SqlParameter>()
			{
				new SqlParameter ("@id_Habitacional", id_Habitacional)
			});

			if (ds.Rows.Count > 0)
			{
				habitacionales.Add(new Habitacional()
				{
					Logo_Habitacional = ds.Rows[0]["Logo_Habitacional"].ToString(),
					Codigo_Habitacional = ds.Rows[0]["Codigo_Habitacional"].ToString(),
					Nombre_Habitacional = ds.Rows[0]["Nombre_Habitacional"].ToString(),
					Direccion_Habitacional = ds.Rows[0]["Direccion_Habitacional"].ToString(),
					Telefono_Oficina = ds.Rows[0]["Telefono_Oficina"].ToString(),
				});
			}

			ViewBag.habitacional = habitacionales;
		}
	}
}