using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_BD.DatabaseHelper;
using System.Data.SqlClient;
using System.Data;
using Proyecto_BD2.Models;

namespace Proyecto_BD2.Controllers
{
	public class HabitacionalesController : Controller
	{
		// GET: CreatePHController

		public ActionResult Index(int id_Habitacional)
		{


			List<Habitacional> habitacionales = new List<Habitacional>();

			DataTable ds = DatabaseHelper.ExecuteStoreProcedure("spGetPH", new List<SqlParameter> { new SqlParameter("@id_Habitacional", id_Habitacional)});

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


			ViewBag.Habitacional = habitacionales;
			return View();
		}
	}
}


		/*public List<Habitacional> GetPH()
		{
			List<Habitacional> habitacionales = new List<Habitacional>();

			DataTable ds = DatabaseHelper.ExecuteStoreProcedure("spGetPH", new List<SqlParameter>());

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


			ViewBag.Habitacional = habitacionales;
			return View("Index");
		}









	}
}

		*/
/*	public ActionResult Index(int id_Habitacional)
	{

		List<Habitacional> habitacionales = new List<Habitacional>();
		foreach (DataRow item in DatabaseHelper.ExecuteStoreProcedure("spGetPH", new List<SqlParameter> { new SqlParameter("@id_Habitacional", id_Habitacional) }).Rows)
		{
			habitacionales.Add(new Habitacional
			{
				Logo_Habitacional = item["Logo_Habitacional"].ToString(),
				Codigo_Habitacional = item["Codigo_Habitacional"].ToString(),
				Nombre_Habitacional = item["Nombre_Habitacional"].ToString(),
				Direccion_Habitacional = item["Direccion_Habitacional"].ToString(),
				Telefono_Oficina = item["Telefono_Oficina"].ToString(),
			});
		}

		ViewBag.Habitacional = habitacionales;

		return View();
	}

	*/