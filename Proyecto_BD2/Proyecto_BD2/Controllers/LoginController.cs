using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_BD.DatabaseHelper;
using System.Data.SqlClient;
using System.Data;
using Proyecto_BD2.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Proyecto_BD2.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidateLogin(string txtUsuario, string txtPass)
        {
            User? user = GetUser(txtUsuario, txtPass);

            if (user != null)
            {
                List<UserAccess>? userAccessList = GetUserAccess(user.ID_Usuario);

                string strUser = JsonConvert.SerializeObject(user);
                string strUserAccessList = JsonConvert.SerializeObject(userAccessList);

                HttpContext.Session.SetString("userSession", strUser);
                HttpContext.Session.SetString("userAccessListSession", strUserAccessList);

                return RedirectToAction(userAccessList[0].Action, userAccessList[0].Controller);
            }

            ViewBag.Error = new ErrorHandler()
            {
                Title = "Login inválido",
                ErrorMessage = "El usuario o contraseña son incorrectos",
                Path = "/Login"
            };

            return View("ErrorHandler");
        }

        private User? GetUser(string txtUsuario, string txtPass)
        {
            DataTable ds = DatabaseHelper.ExecuteStoreProcedure("[spGetUsuarios]", new List<SqlParameter>()
            {
                new SqlParameter("@usuario", txtUsuario),
                new SqlParameter("@pass", txtPass)
            });

            if (ds.Rows.Count > 0)
            {
                User user = new User
                {
                    ID_Usuario = ds.Rows[0]["ID_Usuario"].ToString(),
                    Usuario = txtUsuario,
                    Nombre_Usuario = ds.Rows[0]["Nombre_Usuario"].ToString(),
                    Cedula_Usuario = ds.Rows[0]["Cedula_Usuario"].ToString(),
                    Email_Usuario = ds.Rows[0]["Email_Usuario"].ToString(),
                    Telefono_Usuario = ds.Rows[0]["Telefono_Usuario"].ToString(),
                    Foto_Usuario = ds.Rows[0]["Foto_Usuario"].ToString(),
                    Tipo_Rol = ds.Rows[0]["Tipo_Rol"].ToString(),
                    Logo_Habitacional = ds.Rows[0]["Logo_Habitacional"].ToString(),
                    Codigo_Habitacional = ds.Rows[0]["Codigo_Habitacional"].ToString(),
                    Nombre_Habitacional = ds.Rows[0]["Nombre_Habitacional"].ToString(),
                    Direccion_Habitacional = ds.Rows[0]["Direccion_Habitacional"].ToString(),
                    Telefono_Oficina = ds.Rows[0]["Telefono_Oficina"].ToString(),
                    Marca_Vehiculo = ds.Rows[0]["Marca_Vehiculo"].ToString(),
                    Modelo_Vehiculo = ds.Rows[0]["Modelo_Vehiculo"].ToString(),
                    Placa_Vehiculo = ds.Rows[0]["Placa_Vehiculo"].ToString(),
                    Color_Vehiculo = ds.Rows[0]["Color_Vehiculo"].ToString(),
                };

                return user;
            }
            else
            {
                return null;
            }
        }


        private List<UserAccess>? GetUserAccess(string id_Usuario)
        {
            List<UserAccess> strUserAccessList = new List<UserAccess>();

            DataTable ds = DatabaseHelper.ExecuteStoreProcedure("spGetUsuarioAccess", new List<SqlParameter>()
            {
                new SqlParameter("@id_Usuario", id_Usuario),
            });

            foreach (DataRow row in ds.Rows)
            {
                strUserAccessList.Add(new UserAccess
                {
                    ID_Usuario = row["ID_Usuario"].ToString(),
                    Controller = row["Controller"].ToString(),
                    Action = row["Action"].ToString(),
                    DatabaseAction = row["DatabaseAction"].ToString(),
                });
            }

            return strUserAccessList;
        }

        public IActionResult GetCurrentSessionUserAccess()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("userAccessListSession")))
            {
                List<UserAccess>? userAccessList = JsonConvert.DeserializeObject<List<UserAccess>>(HttpContext.Session.GetString("userAccessListSession"));

                return Json(userAccessList);
            }

            return Ok();
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
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

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View("Index");
        }

        // POST: LoginController/Edit/5
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

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
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

