using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MVC_Project.Areas.Admin.Views.Shared
{
    public class _Footer : PageModel
    {
        private readonly ILogger<_Footer> _logger;

        public _Footer(ILogger<_Footer> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}