using Microsoft.AspNetCore.Mvc;

namespace MVCCoreDemo.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        //[HttpGet]
        //[Route("Category/Index")]
        public string Index(int? id)
        {
            return $"found id : {id} from url";
        }

        [Route("index1/{id}/{name}")]
        public string Index1(int? id, string name)
        {
            return $"found id : {id} and Name: {name} from url";
        }

        [Route("index2/{id}/{categoryName}")]
        public string Index2(int? id, string categoryName)
        {
            return $"found id : {id} and categoryName: {categoryName} from url";
        }
    }
}
