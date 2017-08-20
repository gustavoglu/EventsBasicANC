using Microsoft.AspNetCore.Mvc;

namespace EventsBasicANC.Controllers
{
    public class BaseController : Controller
    {
        protected new IActionResult Response(object obj = null)
        {
            return Ok(new
                {
                    sucess = true,
                    data = obj
                });
        }
    }
}
