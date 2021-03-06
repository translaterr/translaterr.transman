using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Translaterr.Transman.Api.Models;

namespace Translaterr.Transman.Api.Controllers
{
    [Route("api/languages")]
    public class LanguagesController : BaseController
    {
        private readonly ILogger<LanguagesController> _logger;

        public LanguagesController(ILogger<LanguagesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<LanguageModel>> Index()
        {
            _logger.LogDebug("Retrieving a all supported languages");
            return Ok(CultureInfo
                .GetCultures(CultureTypes.AllCultures)
                .Where(culture => culture.Name != string.Empty)
                .Select(culture => new LanguageModel(culture))
                .ToList()
            );
        }
    }
}