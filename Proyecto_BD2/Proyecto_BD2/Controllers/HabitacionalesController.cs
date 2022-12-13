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

				ViewBag.viviendas = ViviendasController.GetViviendas(id_Habitacional);
				return View();
			}
		}

		public ActionResult UpdatePH(IFormFile inputPhoto, int id_Habitacional, string codigo, string nombre, string direccion, string telefonoOficina)
		{

			string? photoPath = null;

			if (inputPhoto != null)
			{
				photoPath =
					"/images/fotos_ph/"
					+ Guid.NewGuid().ToString()
					+ new FileInfo(inputPhoto.FileName).Extension;

				using (
					var stream = new FileStream(
						Directory.GetCurrentDirectory() + "/wwwroot/" + photoPath,
						FileMode.Create
					)
				)
				{
					inputPhoto.CopyTo(stream);
				}
			}

			List<SqlParameter> param = new List<SqlParameter>()
			{
				new SqlParameter("@id_Habitacional", id_Habitacional),
				new SqlParameter("@logo_Habitacional", photoPath),
				new SqlParameter("@codigo_Habitacional", codigo),
				new SqlParameter("@nombre_Habitacional", nombre),
				new SqlParameter("@direccion_Habitacional", direccion),
				new SqlParameter("@telefono_Oficina", telefonoOficina)
			};

			DatabaseHelper.ExecStoreProcedure("spUpdatePH", param);

			return RedirectToAction("Index", "Habitacionales");
		}

		public List<Habitacional> GetPH(int id_Habitacional)
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

			return habitacionales;
		}

		public ActionResult InsertPH(IFormFile inputPhoto, string codigo, string nombre, string direccion, string telefonoOficina, string selectNumViviendas)
		{
			string photoPath;

			if (inputPhoto != null)
			{
				photoPath =
					"/images/fotos_ph/"
					+ Guid.NewGuid().ToString()
					+ new FileInfo(inputPhoto.FileName).Extension;

				using (
					var stream = new FileStream(
						Directory.GetCurrentDirectory() + "/wwwroot/" + photoPath,
						FileMode.Create
					)
				)
				{
					inputPhoto.CopyTo(stream);
				}
			}
			else
			{
				photoPath = "/images/fotos_ph/defaultCondominio.png";
			}

			List<SqlParameter> param = new List<SqlParameter>()
			{
				new SqlParameter("@logo_Habitacional", photoPath),
				new SqlParameter("@codigo_Habitacional", codigo),
				new SqlParameter("@nombre_Habitacional", nombre),
				new SqlParameter("@direccion_Habitacional", direccion),
				new SqlParameter("@telefono_Oficina", telefonoOficina),
				new SqlParameter("@numero_Viviendas", selectNumViviendas),
			};

			DatabaseHelper.ExecStoreProcedure("spInsertPH", param);


			return RedirectToAction("Index", "Habitacionales");
		}

		public ActionResult DeletePH(int id_Habitacional)
		{
			List<SqlParameter> param = new List<SqlParameter>()
			{
				new SqlParameter("@id_Habitacional", id_Habitacional)
			};

			DatabaseHelper.ExecStoreProcedure("spDeletePH", param);

			return RedirectToAction("Index", "Habitacionales");
		}
	}
}