using Microsoft.AspNetCore.Mvc;

namespace PLMVC.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult GetAll()
        {
            BL.Usuario usuario = BL.Usuario.GetAll();

            return View(usuario);
        }

        [HttpGet]
        public IActionResult Form(int? idUsuario)
        {
            BL.Usuario usuario = new BL.Usuario();

            if (idUsuario != null)
            {
                usuario = BL.Usuario.GetById(idUsuario.Value);

                if (usuario.Correct)
                {
                    //DDL DE UNIDADES
                }
            }
            else
            {
                //DDL DE UNIDADES
            }
            return View(usuario);  
        }
    }
}
