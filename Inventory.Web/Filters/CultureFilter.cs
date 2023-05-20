using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Web.Filters
{
    public class CultureFilter : IActionFilter
    {
        private readonly string _culture;

        public CultureFilter(string culture)
        {
            _culture = culture;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Check if the culture of the application is set to the expected value
            var culture = CultureInfo.CurrentCulture.Name;
            if (culture != _culture)
            {
                context.Result = new ContentResult
                {
                    Content = $"Invalid culture. Expected: {_culture}, Actual: {culture}"
                };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do nothing
        }
    }

}
