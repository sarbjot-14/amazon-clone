using Microsoft.AspNetCore.Mvc;

namespace OrdersService.Controllers{
    [Route("api/c/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase{

        public ProductsController(){

        }

        [HttpPost]
        public ActionResult TestInboundConnection(){
            Console.WriteLine("-----> Inbound Post # Command Service");

            return Ok("Inboudn test of from Platforms Controller");
        }

        
    }
}