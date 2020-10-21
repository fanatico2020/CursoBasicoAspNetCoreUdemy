using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site01.Library.Filters
{
    public class LoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Verificar se a session
            if (context.HttpContext.Session.GetString("Login") == null)
            {
                if(context.Controller != null)
                {
                    Controller  controlador = context.Controller as Controller;
                    controlador.TempData["MensagemErro"] = "Faça o Login para ter permissão de entrar nessa página!";
                }
                //Redirecionar
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
        }
    }
}
