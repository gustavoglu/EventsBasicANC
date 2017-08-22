using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventsBasicANC.Controllers
{
    public class BaseController : Controller
    {
        protected new IActionResult Response(object obj = null, bool success = false)
        {
            return Ok(new
                {
                    sucess = success,
                    data = obj
                });
        }

        protected void AdicionaErrosIdentity(IdentityResult result)
        {
            foreach (var erro in result.Errors)
            {
                ModelState.AddModelError(erro.Code, erro.Description);
            }
        }
    }
}
