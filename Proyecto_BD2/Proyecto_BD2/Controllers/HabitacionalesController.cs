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

		public ActionResult Index()
		{
			if (String.IsNullOrEmpty(HttpContext.Session.GetString("userAccessListSession")))
			{
				return RedirectToAction("Index", "Login");
			}
			else
			{

				ViewBag.Habitacional = GetPHs();

				return View();
			}
		}

		public ActionResult Create()
		{

			return View();
		}

		public List<Habitacional> GetPHs()
		{

			DataTable ds = DatabaseHelper.ExecuteStoreProcedure("spGetPHs", null);
			List<Habitacional> habitacionales = new List<Habitacional>();

			foreach (DataRow row in ds.Rows)
			{
				habitacionales.Add(new Habitacional()
				{
					ID_Habitacional = Convert.ToInt32(ds.Rows[0]["ID_Habitacional"]),
					Logo_Habitacional = ds.Rows[0]["Logo_Habitacional"].ToString(),
					Codigo_Habitacional = ds.Rows[0]["Codigo_Habitacional"].ToString(),
					Nombre_Habitacional = ds.Rows[0]["Nombre_Habitacional"].ToString(),
					Direccion_Habitacional = ds.Rows[0]["Direccion_Habitacional"].ToString(),
					Telefono_Oficina = ds.Rows[0]["Telefono_Oficina"].ToString(),
				});
			}

			return habitacionales;
		}


		public ActionResult UpdatePH(IFormFile inputPhoto, int id_Habitacional, string codigo, string nombre, string direccion, string telefonoOficina)
		{

			string? photoPath = null;

			if (inputPhoto != null)
			{
				photoPath =
					"/img/fotos_ph/"
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


		public ActionResult Editar(int id_Habitacional)
		{

			ViewBag.habitacional = GetPH(id_Habitacional);
			return View();

		}

		private Habitacional GetPH(int id_Habitacional)
		{
			List<SqlParameter> param = new List<SqlParameter>()
			{
				new SqlParameter("@id_Habitacional", id_Habitacional)
			};

			DataTable ds = DatabaseHelper.ExecuteStoreProcedure("spGetPH", param);

			Habitacional habitacional = new Habitacional()
			{
				ID_Habitacional = Convert.ToInt32(ds.Rows[0]["id_Habitacional"]),
				Logo_Habitacional = ds.Rows[0]["Logo_Habitacional"].ToString(),
				Codigo_Habitacional = ds.Rows[0]["Codigo_Habitacional"].ToString(),
				Nombre_Habitacional = ds.Rows[0]["Nombre_Habitacional"].ToString(),
				Direccion_Habitacional = ds.Rows[0]["Direccion_Habitacional"].ToString(),
				Telefono_Oficina = ds.Rows[0]["Telefono_Oficina"].ToString(),
			};

			return habitacional;
		}


		public ActionResult CreatePh(IFormFile inputPhoto, string codigo, string nombre, string direccion, string telefono, string selectNumViviendas)
		{
			string photoPath;

			if (inputPhoto != null)
			{
				photoPath =
					"/img/fotos_ph/"
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
				photoPath = "/img/fotos_ph/default.jpg";
			}

			List<SqlParameter> param = new List<SqlParameter>()
			{
				new SqlParameter("@logo", photoPath),
				new SqlParameter("@codigo", codigo),
				new SqlParameter("@nombre", nombre),
				new SqlParameter("@direccion", direccion),
				new SqlParameter("@telefono", telefono),
				new SqlParameter("@numeroViviendas", selectNumViviendas),
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