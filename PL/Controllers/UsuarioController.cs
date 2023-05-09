using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetAll()
        {
            ML.Result result = BL.Usuario.GetAll();
            ML.Usuario usuario = new ML.Usuario();
            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                return View(usuario);
            }
            else
            {
                return View(usuario);
            }
            
        }
        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
           

            if (IdUsuario == null)
            {
                return View(usuario);
            }
            else
            {
                ML.Result result = BL.Usuario.GetById(IdUsuario.Value);
                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                    return View(usuario);
                }
                else
                {
                    ViewBag.Message = "ocurrio un problema";
                    return View("Modal");

                }
            }
          
        }
        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            if (usuario.IdUsuario == 0)
            {
                result = BL.Usuario.Add(usuario);

                if (result.Correct)
                {
                    ViewBag.Message = "Registrado con éxito";
                    return View("Modal");
                }
                else
                {
                    ViewBag.Message = "ocurrio problema";
                    return View("Modal");
                }
            }
            else
            {
                result = BL.Usuario.Update(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = "actualizado";
                    return View("Modal");
                }
                else
                {
                    ViewBag.Message = "ocurrio un problema";
                    return View("Modal");
                }
            }

        }
        [HttpGet]
        public ActionResult Delete(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.Delete(usuario);
            if (result.Correct)
            {
                ViewBag.Message = "Eliminado exitosamente";
                return View("Modal");
            }
            else
            {
                ViewBag.Message = "ocurrio un problema";
                return View("Modal");
            }
        }
        [HttpPost]
        public JsonResult CURP(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.CURP(usuario);
            return Json(result);
        }
    }
         

}