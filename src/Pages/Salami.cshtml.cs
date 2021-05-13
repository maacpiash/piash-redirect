using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Redirect.Pages
{
    public class SalamiModel : PageModel
    {
        private readonly ILogger<SalamiModel> _logger;

        public SalamiModel(ILogger<SalamiModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
