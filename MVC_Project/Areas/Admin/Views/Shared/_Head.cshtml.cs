using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MVC_Project.Areas.Admin.Views.Shared
{
    public class _Head : PageModel
    {
        private readonly ILogger<_Head> _logger;

        public _Head(ILogger<_Head> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}