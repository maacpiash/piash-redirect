using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Redirect
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {

        private readonly ILogger<Shortcut> _logger;
        private readonly ShortcutService _shortcutService;

        public Controller(ILogger<Shortcut> logger, ShortcutService shortcutService)
        {
            _logger = logger;
            _shortcutService = shortcutService;
        }

        [HttpGet("{pageKey}")]
        public RedirectResult Get(string pageKey)
        {
          string realUrl = _shortcutService.Get(pageKey).RealUrl;
          if (realUrl is null)
            return Redirect("https://www.maacpiash.com/");
          return RedirectPermanent(realUrl);
        }
    }
}
