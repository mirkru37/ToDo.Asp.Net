using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[Route("test")]
public class TestController : Controller
{
    // GET
    [Route("action")]
    public IActionResult Index()
    {
        return View();
    }
}