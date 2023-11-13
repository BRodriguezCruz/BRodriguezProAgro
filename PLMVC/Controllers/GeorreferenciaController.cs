using Microsoft.AspNetCore.Mvc;

namespace PLMVC.Controllers
{
    public class GeorreferenciaController : Controller
    {
        public IActionResult GetAll()
        {
            BL.Georreferencia georreferencia = BL.Georreferencia.GetAll();

            return View(georreferencia);
        }
    }
}
