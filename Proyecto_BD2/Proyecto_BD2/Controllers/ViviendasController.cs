﻿using Microsoft.AspNetCore.Http;
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
		public ActionResult Index(int idProyectoHabitacional)
		{
			if (String.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
			{
				return RedirectToAction("Index", "Login");
			}
			else
			{
				ViewBag.usuario = JsonConvert.DeserializeObject(HttpContext.Session.GetString("usuario"));
				ViewBag.viviendas = CargarViviendas(idProyectoHabitacional);
				return View();
			}
		}

		public static List<Vivienda> CargarViviendas(int idProyectoHabitacional)
		{
			List<SqlParameter> param = new List<SqlParameter>()
			{
				new SqlParameter("@idProyectoHabitacional", idProyectoHabitacional)
			};
			DataTable ds = DatabaseHelper.ExecuteStoreProcedure("SP_ObtenerViviendas", param);
			List<Vivienda> viviendasList = new List<Vivienda>();

			foreach (DataRow row in ds.Rows)
			{
				viviendasList.Add(new Vivienda()
				{
					idVivienda = Convert.ToInt32(row["idVivienda"]),
					numeroVivienda = row["numeroVivienda"].ToString(),
					descripcion = row["descripcion"].ToString(),
					numeroHabitaciones = Convert.ToInt32(row["numeroHabitaciones"] is DBNull ? 0 : row["numeroHabitaciones"]),
					cochera = Convert.ToInt32(row["cochera"] is DBNull ? 0 : row["cochera"]),
					idProyectoHabitacional = Convert.ToInt32(row["idProyectoHabitacional"]),
					idPersona = Convert.ToInt32(row["idPersona"] is DBNull ? 0 : row["idPersona"])
				});
			}

			return viviendasList;
		}

		public ActionResult EliminarVivienda(int idVivienda, int idProyectoHabitacional)
		{
			DatabaseHelper.ExecStoreProcedure("SP_EliminarVivienda", new List<SqlParameter>()
			{
				new SqlParameter("@idVivienda", idVivienda)
			});

			return RedirectToAction("Editar", "Condominios", new { idProyectoHabitacional = idProyectoHabitacional });
		}

		public ActionResult Agregar()
		{
			if (String.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
			{
				return RedirectToAction("Index", "Login");
			}
			else
			{
				ViewBag.usuario = JsonConvert.DeserializeObject(HttpContext.Session.GetString("usuario"));
				ViewBag.condominios = CargarCondominios();
				return View();
			}
		}

		public ActionResult AgregarVivienda(string numeroVivienda, string descripcion, int numeroHabitaciones, int cochera, int selectCondominio)
		{

			List<SqlParameter> param = new List<SqlParameter>()
			{
				new SqlParameter("@numeroVivienda", numeroVivienda),
				new SqlParameter("@descripcion", descripcion),
				new SqlParameter("@numeroHabitaciones", numeroHabitaciones),
				new SqlParameter("@cochera", cochera),
				new SqlParameter("@idProyectoHabitacional", selectCondominio),
			};

			DatabaseHelper.ExecStoreProcedure("SP_AgregarVivienda", param);


			return RedirectToAction("Index", "Condominios");
		}

		public ActionResult Editar(int idVivienda)
		{
			if (String.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
			{
				return RedirectToAction("Index", "Login");
			}
			else
			{
				ViewBag.usuario = JsonConvert.DeserializeObject(HttpContext.Session.GetString("usuario"));
				ViewBag.viviendas = CargarVivienda(idVivienda);
				/* ViewBag.usuariosDD = SP_ObtenerUsuariosDDL(); */
				return View();
			}
		}

		private List<Vivienda> CargarVivienda(int idVivienda)
		{
			List<SqlParameter> param = new List<SqlParameter>()
			{
				new SqlParameter("@idVivienda", idVivienda)
			};
			DataTable ds = DatabaseHelper.ExecuteStoreProcedure("SP_ObtenerVivienda", param);
			List<Vivienda> viviendasList = new List<Vivienda>();

			foreach (DataRow row in ds.Rows)
			{
				viviendasList.Add(new Vivienda()
				{
					idVivienda = Convert.ToInt32(row["idVivienda"]),
					numeroVivienda = row["numeroVivienda"].ToString(),
					descripcion = row["descripcion"].ToString(),
					numeroHabitaciones = Convert.ToInt32(row["numeroHabitaciones"]),
					cochera = Convert.ToInt32(row["cochera"]),
					idProyectoHabitacional = Convert.ToInt32(row["idProyectoHabitacional"]),
					idPersona = Convert.ToInt32(row["idPersona"] is DBNull ? 0 : row["idPersona"])
				});
			}

			return viviendasList;
		}

		public ActionResult UpdateVivienda(int idVivienda, string numeroVivienda, string descripcion, int numeroHabitaciones, int cochera, int SelectUser)
		{

			List<SqlParameter> param = new List<SqlParameter>()
			{
				new SqlParameter("@idVivienda", idVivienda),
				new SqlParameter("@numeroVivienda", numeroVivienda),
				new SqlParameter("@descripcion", descripcion),
				new SqlParameter("@numeroHabitaciones", numeroHabitaciones),
				new SqlParameter("@cochera", cochera),
				new SqlParameter("@idPersona", SelectUser),
			};

			DatabaseHelper.ExecStoreProcedure("SP_UpdateVivienda", param);

			return RedirectToAction("Index", "Viviendas");
		}

		private List<Usuario> SP_ObtenerUsuariosDDL()
		{
			DataTable ds = DatabaseHelper.ExecuteStoreProcedure("SP_ObtenerUsuariosDDL", null);
			List<Usuario> usuariosList = new List<Usuario>();

			foreach (DataRow row in ds.Rows)
			{
				usuariosList.Add(new Usuario()
				{
					idPersona = Convert.ToInt32(row["idPersona"]),
					nombre = row["nombreCompleto"].ToString(),

				});
			}
			return usuariosList;
		}

		private List<Condominio> CargarCondominios()
		{
			DataTable ds = DatabaseHelper.ExecuteSelect("SELECT idProyectoHabitacional, nombre FROM proyectosHabitacionales", null);
			List<Condominio> listadoCondominios = new List<Condominio>();

			foreach (DataRow row in ds.Rows)
			{
				listadoCondominios.Add(
					new Condominio()
					{
						idProyectoHabitacional = Convert.ToInt32(row["idProyectoHabitacional"]),
						nombre = row["nombre"].ToString(),
					}
				);
			}

			return listadoCondominios;
		}
	}




}
}
