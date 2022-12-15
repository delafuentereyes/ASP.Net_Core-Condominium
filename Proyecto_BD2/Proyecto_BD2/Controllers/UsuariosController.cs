using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto_BD.DatabaseHelper;
using Proyecto_BD2.Models;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace Proyecto_BD2.Controllers
{
	public class UsuariosController : Controller
	{
		public IActionResult Index(string busqueda)
		{
			
				
				ViewBag.Usuarios = CargarUsuarios(busqueda);
				return View();
			
		}

		private List<User> CargarUsuarios(string busqueda)
		{
			if (busqueda == null)
			{
				busqueda = "";
			}

			DataTable ds = DatabaseHelper.ExecuteStoreProcedure("SP_ObtenerUsuariosAll", new List<SqlParameter>(){
				new SqlParameter("@busqueda", busqueda),
			});

			List<User> users = new List<User>();

			foreach (DataRow row in ds.Rows)
			{
				users.Add(new 
					User()
				{
					ID_Usuario = row["ID_Usuario"].ToString(),
                    Nombre_Usuario = row["Nombre_Usuario"].ToString(),
                    Cedula_Usuario = row["Cedula_Usuario"].ToString(),
					Email_Usuario = row["Email_Usuario"].ToString(),
					Tipo_Rol = row["Tipo_Rol"].ToString(),
					
					//idPersona = Convert.ToInt32(row["idPersona"]),
				});
			}

			return users;
		}

		public IActionResult Agregar()
		{
			if (String.IsNullOrEmpty(HttpContext.Session.GetString("userSession")))
			{
				return RedirectToAction("Index", "Login");
			}
			else
			{
				ViewBag.User = JsonConvert.DeserializeObject(HttpContext.Session.GetString("userSession"));
				ViewBag.roles = CargarRolesUsuarios();
				ViewBag.habitacionales = CargarHabitacionales();
				return View();
			}
		}

		private List<TipoRol> CargarRolesUsuarios()
		{
			DataTable ds = DatabaseHelper.ExecuteSelect("SELECT * FROM tblRoles WHERE Tipo_Rol != 'Admin'", null);
			List<TipoRol> roles = new List<TipoRol>();

			foreach (DataRow row in ds.Rows)
			{
				roles.Add(
					new TipoRol()
					{
						ID_Rol = row["ID_Rol"].ToString(),
						Tipo_Rol = row["Tipo_Rol"].ToString(),
					}
				);
			}

			return roles;
		}

		private List<Habitacional> CargarHabitacionales()
		{
			DataTable ds = DatabaseHelper.ExecuteSelect("SELECT ID_Habitacional, Nombre_Habitacional FROM tblPHabitacionales", null);
			List<Habitacional> habitacionales = new List<Habitacional>();

			foreach (DataRow row in ds.Rows)
			{
				habitacionales.Add(
					new Habitacional()
					{
						ID_Habitacional = Convert.ToInt32(row["ID_Habitacional"]),
						Nombre_Habitacional = row["Nombre_Habitacional"].ToString(),
					}
				);
			}

			return habitacionales;
		}

		public IActionResult AgregarUsuario(string txtNombre,string txtUsuario,string txtCedula, IFormFile inputPhoto, 
			string txtEmail, string txtPassword, string selectRol,
			string selectCondominio, string selectViviendas)
		{
			string photoPath;

			if (inputPhoto != null)
			{
				photoPath =
					"/img/"
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
				photoPath = "/imag/0.jpg";
			}

			DatabaseHelper.ExecStoreProcedure(
				"spInsertUsuarios",
				new List<SqlParameter>()
				{
					new SqlParameter("@nombre_Usuario", txtNombre),
					new SqlParameter("@cedula_Usuario", txtCedula),
					new SqlParameter("@email_Usuario", txtEmail),
					new SqlParameter("@foto_Usuario", photoPath),
					new SqlParameter("@usuario", txtUsuario),
					new SqlParameter("@pass", txtPassword),
					new SqlParameter("@id_Rol", selectRol),
					new SqlParameter("@id_Habitacional", selectCondominio),
					new SqlParameter("@id_Vivienda", selectViviendas) //agregar en sp
				}
			);

			// ENVIAR EMAIL DE CONFIRMACION
			/*ktvnsukeryuvfzla*/

			var emailOwner = "testmm311@gmail.com";
			var emailPassword = "ktvnsukeryuvfzla";

			using (MailMessage mm = new MailMessage(emailOwner, txtEmail))
			{
				mm.Subject = "Confirmaci�n de cuenta";

				mm.IsBodyHtml = true;


				using (var sr = new StreamReader("wwwroot/html/welcome_mail.txt"))
				{
					// Read the stream as a string, and write the string to the console.
					string body = sr.ReadToEnd()
						.Replace("@CLIENTNAME", txtNombre)
						.Replace("@ClientPassword", txtPassword)
						.Replace("@ClientEmail", txtEmail);

					mm.Body = body;
				}

				SmtpClient smtp = new SmtpClient();
				smtp.Host = "smtp.gmail.com";
				smtp.EnableSsl = true;
				NetworkCredential NetworkCred = new NetworkCredential(emailOwner, emailPassword);
				smtp.UseDefaultCredentials = false;
				smtp.Credentials = NetworkCred;
				smtp.Port = 587;
				smtp.Send(mm);
			}

			// FIN EMAL CONFIRMATION

			return RedirectToAction("Index", "Usuarios");
		}
		public ActionResult Editar(int id_Usuario)
		{
			if (String.IsNullOrEmpty(HttpContext.Session.GetString("userSession")))
			{
				return RedirectToAction("Index", "Login");
			}
			else
			{
				ViewBag.usuario = JsonConvert.DeserializeObject(HttpContext.Session.GetString("userSession"));
				ViewBag.rolesUsuarios = CargarRolesUsuarios();
				ViewBag.usuarioEdit = CargarUsuario(id_Usuario);
				return View();
			}
		}

		private User CargarUsuario(int id_Usuario)
		{
			List<SqlParameter> param = new List<SqlParameter>()
			{
				new SqlParameter("@id_Usuario",id_Usuario )
			};
			DataTable ds = DatabaseHelper.ExecuteStoreProcedure("SP_ObtenerUsuario", param);

			User usuario = new User()
			{
				//idPersona = Convert.ToInt32(ds.Rows[0]["idPersona"]),
				Nombre_Usuario = ds.Rows[0]["Nombre_Usuario"].ToString(),
				Cedula_Usuario = ds.Rows[0]["Cedula_Usuario"].ToString(),
				Foto_Usuario = ds.Rows[0]["Foto_Usuario"].ToString(),
				Email_Usuario = ds.Rows[0]["Email_Usuario"].ToString(),
				Usuario = ds.Rows[0]["Usuario"].ToString(),
				Pass = ds.Rows[0]["Pass"].ToString(),
				Tipo_Rol = ds.Rows[0]["Tipo_Rol"].ToString(),
				ID_Rol = ds.Rows[0]["ID_Rol"].ToString(),
				ID_Usuario = ds.Rows[0]["ID_Usuario"].ToString(),
            };

			return usuario;
		}

		public ActionResult UpdateUsuario(int idPersona, int idUsuario, string txtNombre,
			string txtCedula, IFormFile inputPhoto,
			string txtEmail, string txtUsuario, string txtPassword, string selectRol)
		{

			string? photoPath = null;

			if (inputPhoto != null)
			{
				photoPath =
					"/img/"
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
					//new SqlParameter("@idPersona", idPersona),
					new SqlParameter("@id_Usuario", idUsuario),
					new SqlParameter("@nombre_Usuario", txtNombre),
					new SqlParameter("@cedula_Usuario", txtCedula),
					new SqlParameter("@foto_Usuario", photoPath),
					new SqlParameter("@email_Usuario", txtEmail),
					new SqlParameter("@usuario", txtUsuario),
					new SqlParameter("@pass", txtPassword),
					new SqlParameter("@id_Rol", selectRol),
			};

			DatabaseHelper.ExecStoreProcedure("spUpdateUsuarios", param);

			return RedirectToAction("Index", "Usuarios");
		}

		public ActionResult EliminarUsuario(int idUsuario)
		{
			List<SqlParameter> param = new List<SqlParameter>()
			{
				 new SqlParameter("@id_Usuario", idUsuario)
			};

			DatabaseHelper.ExecStoreProcedure("spDeleteUsuarios", param);

			return RedirectToAction("Index", "Usuarios");
		}

		public List<Vivienda> CargarViviendasDD(int idHabitacional)
		{
			List<SqlParameter> param = new List<SqlParameter>()
			{
				new SqlParameter("@id_Habitacional", idHabitacional)
			};

			DataTable ds = DatabaseHelper.ExecuteStoreProcedure("spGetPH", param);
			List<Vivienda> viviendas = new List<Vivienda>();

			foreach (DataRow row in ds.Rows)
			{
				viviendas.Add(new Vivienda()
				{
					ID_Vivienda = Convert.ToInt32(row["idVivienda"]),
					Numero_Vivienda = row["numeroVivienda"].ToString(),
					Desc_Vivienda = row["descripcion"].ToString(),
				});
			}

			return viviendas;
		}

		[HttpGet]
		public JsonResult GetViviendas(int pidHabitacional)
		{
			return Json(CargarViviendasDD(pidHabitacional));
		}
	}
}


