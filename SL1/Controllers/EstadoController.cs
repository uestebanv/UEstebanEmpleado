using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class EstadoController : Controller
    {
        [EnableCors("Api")]
        [HttpGet]
        [Route("api/Estado/GetAll")]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Estado.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
