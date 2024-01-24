using AspCoreMvcSAML.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Identity.Web;
using Microsoft.Identity.Abstractions;
using Microsoft.AspNetCore.Http;

namespace AspCoreMvcSAML.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IDownstreamApi _downstreamApi;
        private readonly ILogger<HomeController> _logger;
        public const string SessionKeyName = "UserName";
        public const string SessionKeyAge = "UserEmail";
        public HomeController(ILogger<HomeController> logger, IDownstreamApi downstreamApi)
        {
            _logger = logger;
            _downstreamApi = downstreamApi;;
            

        }
        private void SetSession()
        {
            var claim = User.Claims.Where(x => x.Type == "emails").FirstOrDefault();

            string userName = claim==null?"": claim.Value;


            if (string.IsNullOrEmpty(Request.HttpContext.Session.GetString(SessionKeyName)))
            {
                Request.HttpContext.Session.SetString(SessionKeyName, userName);
                Request.HttpContext.Session.SetInt32(SessionKeyAge, 73);
            }
            var name = Request.HttpContext.Session.GetString(SessionKeyName);
            var age = Request.HttpContext.Session.GetInt32(SessionKeyAge).ToString();

            _logger.LogInformation("Session Name: {Name}", name);
            _logger.LogInformation("Session Age: {Age}", age);
        }
        [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")]
        public async Task<IActionResult> Index()
        {
            SetSession();
            var ctl = this.Request;
            //using var response = await _downstreamApi.CallApiForUserAsync("DownstreamApi").ConfigureAwait(false);
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    var apiResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            //    ViewData["ApiResult"] = apiResult;
            //}
            //else
            //{
            //    var error = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            //    throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}: {error}");
            //};
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
