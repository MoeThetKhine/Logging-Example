using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerilogExample.Models;
using Serilog;
using Newtonsoft.Json;

namespace SerilogExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;

        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
        }
        #region Get blogs
        [HttpGet]
        public IActionResult GetBlog() 
        {
            List<BlogDataModel> lst = new()
            {
               new BlogDataModel
               {
                   BlogId = Guid.NewGuid(),
                   BlogTitle = "Blog 1",
                   BlogAuthor = "Author",
                   BlogContent = "Content"
               },
               new BlogDataModel
               {
                   BlogId = Guid.NewGuid(),
                   BlogTitle = "Blog 2",
                   BlogAuthor = "Author",
                   BlogContent = "Content"
               },
               new BlogDataModel
               {
                   BlogId = Guid.NewGuid(),
                   BlogTitle = "Blog 3",
                   BlogAuthor = "Author",
                   BlogContent = "Content"
               },
            };
            _logger.LogInformation("Blog list =>" + JsonConvert.SerializeObject(lst));
            return Ok(lst);
        }
        #endregion

        #region Test logging
        [HttpGet("texting")]
        public IActionResult TestLogging()
        {
                Log.Debug("test logging");
                return Ok();
        }
        #endregion

    }
}

