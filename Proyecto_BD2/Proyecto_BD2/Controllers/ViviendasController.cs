using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto_BD.DatabaseHelper;
using Proyecto_BD2.Models;
using System.Data.SqlClient;
using System.Data;

namespace Proyecto_BD2.Controllers
{
	public class ViviendasController : Controller
	{
		public ActionResult Index(int id_Habitacional)
		{
			if (String.IsNullOrEmpty(HttpContext.Session.GetString("userAccessListSession")))
			{
				return RedirectToAction("Index", "Login");
			}
			else
			{
				ViewBag.viviendas = GetViviendas(id_Habitacional);

				return View();
			}
		}

		public static List<Vivienda> GetViviendas(int id_Habitacional)
		{
			List<SqlParameter> param = new List<SqlParameter>()
			{
				new SqlParameter("@id_Habitacional", id_Habitacional)
			};
			DataTable ds = DatabaseHelper.ExecuteStoreProcedure("spGetViviendas", param);
			List<Vivienda> viviendas = new List<Vivienda>();

			foreach (DataRow row in ds.Rows)
			{
				viviendas.Add(new Vivienda()
				{
					ID_Vivienda = Convert.ToInt32(row["ID_Vivienda"]),
					Numero_Vivienda = row["Numero_Vivienda"].ToString(),
					Desc_Vivienda = row["Desc_Vivienda"].ToString(),
					Numero_Habitaciones = Convert.ToInt32(row["Numero_Habitaciones"] is DBNull ? 0 : row["Numero_Habitaciones"]),
					Cochera = Convert.ToInt32(row["Cochera"] is DBNull ? 0 : row["Cochera"]),
					ID_Habitacional = Convert.ToInt32(row["ID_Habitacional"]),
					ID_Usuario = Convert.ToInt32(row["ID_Usuario"] is DBNull ? 0 : row["ID_Usuario"])
				});
			}

			return viviendas;
		}

		public ActionResult DeleteVivienda(int id_Vivienda, int id_Habitacional)
		{
			DatabaseHelper.ExecStoreProcedure("spDeleteViviendas", new List<SqlParameter>()
			{
				new SqlParameter("@id_Vivienda", id_Vivienda)
			});

			return RedirectToAction("Editar", "Condominios", new { id_Habitacional = id_Habitacional });
		}

		public ActionResult Create()
		{
			if (String.IsNullOrEmpty(HttpContext.Session.GetString("userAccessListSession")))
			{
				return RedirectToAction("Index", "Login");
			}
			else
			{
				ViewBag.Habitacional = LoadPHs();

				return View();
			}
		}

		public ActionResult AddVivienda(string numeroVivienda, string desc_vivienda, int numeroHabitaciones, int cochera, int selectCondominio)
		{

			List<SqlParameter> param = new List<SqlParameter>()
			{
				new SqlParameter("@numero_Vivienda", numeroVivienda),
				new SqlParameter("@desc_Vivienda", desc_vivienda),
				new SqlParameter("@numero_Habitaciones", numeroHabitaciones),
				new SqlParameter("@cochera", cochera),
				new SqlParameter("@id_Habitacional", selectCondominio),
			};

			DatabaseHelper.ExecStoreProcedure("spCreateViviendas", param);


			return RedirectToAction("Index", "Condominios");
		}

		public ActionResult Edit(int id_Vivienda)
		{
			if (String.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
			{
				return RedirectToAction("Index", "Login");
			}
			else
			{
				ViewBag.viviendas = LoadVivienda(id_Vivienda);

				return View();
			}
		}

		private List<Vivienda> LoadVivienda(int id_Vivienda)
		{
			List<SqlParameter> param = new List<SqlParameter>()
			{
				new SqlParameter("@id_Vivienda", id_Vivienda)
			};
			DataTable ds = DatabaseHelper.ExecuteStoreProcedure("spGetVivienda", param);
			List<Vivienda> viviendasList = new List<Vivienda>();

			foreach (DataRow row in ds.Rows)
			{
				viviendasList.Add(new Vivienda()
				{
					ID_Vivienda = Convert.ToInt32(row["ID_Vivienda"]),
					Numero_Vivienda = row["Numero_Vivienda"].ToString(),
					Desc_Vivienda = row["Desc_Vivienda"].ToString(),
					Numero_Habitaciones = Convert.ToInt32(row["Numero_Habitaciones"]),
					Cochera = Convert.ToInt32(row["Cochera"]),
					ID_Habitacional = Convert.ToInt32(row["ID_Habitacional"]),
					ID_Usuario = Convert.ToInt32(row["ID_Usuario"] is DBNull ? 0 : row["ID_Usuario"])
				});
			}

			return viviendasList;
		}

		public ActionResult UpdateVivienda(int idVivienda, string numeroVivienda, string descripcion, int numeroHabitaciones, int cochera, int SelectUser)
		{

			List<SqlParameter> param = new List<SqlParameter>()
			{
				new SqlParameter("@id_Vivienda", idVivienda),
				new SqlParameter("@numero_Vivienda", numeroVivienda),
				new SqlParameter("@desc_Vivienda", descripcion),
				new SqlParameter("@numero_Habitaciones", numeroHabitaciones),
				new SqlParameter("@cochera", cochera),
				new SqlParameter("@id_Usuario", SelectUser),
			};

			DatabaseHelper.ExecStoreProcedure("spUpdateVivienda", param);

			return RedirectToAction("Index", "Viviendas");
		}

		private List<User> spObtenerUsuarios()
		{
			DataTable ds = DatabaseHelper.ExecuteStoreProcedure("spGetUsuarios", null);
			List<User> usuarios = new List<User>();

			foreach (DataRow row in ds.Rows)
			{
				usuarios.Add(new User()
				{
					ID_Usuario = row["ID_Usuario"].ToString(),
					Nombre_Usuario = row["Nombre_Usuario"].ToString(),

				});
			}
			return usuarios;
		}

		private List<Habitacional> LoadPHs()
		{
			DataTable ds = DatabaseHelper.ExecuteStoreProcedure("SELECT ID_Habitacional, Nombre_Habitacional FROM tblPHabitacionales", null);
			List<Habitacional> habitacionales = new List<Habitacional>();

			foreach (DataRow row in ds.Rows)
			{
				habitacionales.Add(
					new Habitacional()
					{
						ID_Habitacional = Convert.ToInt32(row["ID_Habitacional"]),

                        Nombre_Habitacional = row["nombre"].ToString(),
					}
				);
			}

			return habitacionales;
		}
	}
}

