
using Microsoft.AspNetCore.Mvc.Filters;

using System.Data;

using System.Text;

namespace PAPELERIANGELESC.Permisos
{
    public class ValidarSessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
          
            base.OnActionExecuting(filterContext);
        }
    }
}
