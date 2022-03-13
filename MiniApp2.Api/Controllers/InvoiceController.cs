using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MiniApp2.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInvoice()
        {
            var userName = HttpContext.User.Identity.Name;

            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            // veri tabanında userId veya userName alanları üzerinden gerekli, dataları çek.
            // stockId stockQuantity Category UserId/UserName

            return Ok($"Invoice işlemleri -> UserName: {userName} - UserId: {userIdClaim.Value}");
        }
    }
}