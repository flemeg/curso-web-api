using System;
using Microsoft.AspNetCore.Mvc;

namespace MeuWebApi.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        public MainController()
        {
        }


        public ActionResult CustomResponse(object result = null)
        {
            if (Validated())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = GetErrors()
            });
        }

        protected string GetErrors()
        {
            return string.Empty;
        }


        public bool Validated()
        {


            return true;
        }
    }
}
