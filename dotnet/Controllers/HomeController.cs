using System.Text;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace dotnet.Controllers
{
    [ApiController]
    [Route("/")]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public async Task Get()
        {

            Response.StatusCode = (int)HttpStatusCode.PartialContent;
            // NOTE: Browser buffer text data, so content has to be something to appear right away
            Response.ContentType = "application/json";

            await Response.Body.WriteAsync(Encoding.UTF8.GetBytes("["));
            await Response.Body.FlushAsync();

            for (int i = 0; i <= 5; i++)
            {
                var comma = i < 5 ? ", " : "";
                var content = $"{{ \"item\": {i} }}{comma}";
                await Response.Body.WriteAsync(Encoding.UTF8.GetBytes(content));
                await Response.Body.FlushAsync();
                await Task.Delay(1000);
            }

            await Response.Body.WriteAsync(Encoding.UTF8.GetBytes("]"));
            await Response.Body.FlushAsync();
        }
    }
}
