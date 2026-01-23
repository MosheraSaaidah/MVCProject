using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MVC_Project.Areas.Admin.Views.Shared
{
    public class _Script : PageModel
    {
        private readonly ILogger<_Script> _logger;

        public _Script(ILogger<_Script> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}