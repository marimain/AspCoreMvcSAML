using AspCoreMvcSAML.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Identity.Web;
using Microsoft.Identity.Abstractions;
using AspCoreMvcSAML.Models;

namespace AspCoreMvcSAML.Controllers
{
    public class PatientController : Controller
    {
        private readonly IDownstreamApi _downstreamApi;
        private readonly ILogger<HomeController> _logger;
        public PatientController(ILogger<HomeController> logger, IDownstreamApi downstreamApi)
        {
            _logger = logger;
            _downstreamApi = downstreamApi; ;
        }
        public ActionResult Patients(PatientViewModel pats)
        {
            pats = new PatientViewModel();
            return View("Patients",pats);
        }
    }
}
