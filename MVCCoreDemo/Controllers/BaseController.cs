using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;

namespace MVCCoreDemo.Controllers
{
    public class BaseController : Controller
    {
        public string LoggedInUser { get; set; }
    }
}
