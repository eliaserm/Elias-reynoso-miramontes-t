using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace tesrapidof.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? tipo, string nombre,string desc, int? error,string mensaje)
        {
            //Cndb.clsExamen clas = new Cndb.clsExamen(1);
            //var f = clas.Insertar(7, "molinas", "master");
            //var fd = f.Estado;
            ViewBag.estado = 0;
            if (tipo != null)
            {
                Cndb.clsExamen clas = new Cndb.clsExamen((int)tipo);
                ViewBag.lita = clas.Mostrar(nombre, desc);
                ViewBag.estado = 1;
            }
            ViewBag.error = error;
            if(error == 1)
            {
                ViewBag.error = "Error:" + mensaje;
            }
            else
            {
                if (error != null)
                {
                    ViewBag.error = "Exito:" + mensaje;
                }
            }
            return View();           

        }
        public ActionResult insertar(int? tipo,int? id, string nombre, string desc)
        {

                Cndb.clsExamen clas = new Cndb.clsExamen((int)tipo);
                var result = clas.Insertar((int)id,nombre,desc);
                if(result.Estado == false)
            {
                    return RedirectToAction("index", "Home", new {tipo = tipo,nombre = nombre, desc= desc, error = 1, mensaje = result.desc});
                }
                else 
                { 
                    return RedirectToAction("index", "Home", new {tipo = tipo,nombre = nombre, desc= desc, error = 0, mensaje = result.desc});
                }

        }
        public ActionResult actualizar(int? tipo, int? id, string nombre, string desc)
        {

            Cndb.clsExamen clas = new Cndb.clsExamen((int)tipo);
            var result = clas.Update((int)id, nombre, desc);
            if (result.Estado == false)
            {
                return RedirectToAction("index", "Home", new { tipo = tipo, nombre = nombre, desc = desc, error = 1, mensaje = result.desc });
            }
            else
            {
                return RedirectToAction("index", "Home", new { tipo = tipo, nombre = nombre, desc = desc, error = 0, mensaje = result.desc });
            }

        }
        public ActionResult eliminar(int? tipo, int? id, string nombre, string desc)
        {

            Cndb.clsExamen clas = new Cndb.clsExamen((int)tipo);
            var result = clas.Eliminar((int)id);
            if (result.Estado == false)
            {
                return RedirectToAction("index", "Home", new { tipo = tipo, nombre = nombre, desc = desc, error = 1, mensaje = result.desc });
            }
            else
            {
                return RedirectToAction("index", "Home", new { tipo = tipo, nombre = nombre, desc = desc, error = 0, mensaje = result.desc });
            }

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}