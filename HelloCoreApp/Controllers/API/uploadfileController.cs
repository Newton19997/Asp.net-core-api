using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloCoreApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class uploadfileController : ControllerBase
        
    {
        IHostingEnvironment _hostingEnvironment;
        public uploadfileController(IHostingEnvironment hostingEnvironment)
        {         
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/<uploadfileController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<uploadfileController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        //for image upload
        [HttpPost, DisableRequestSizeLimit]    
        public IActionResult uploadfile()
        {
            try
            {

                //------link for------https://www.youtube.com/watch?v=v67NunIp5w8---------------
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex}");
            }

        }
        //end image upload


        // POST api/<uploadfileController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<uploadfileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<uploadfileController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
