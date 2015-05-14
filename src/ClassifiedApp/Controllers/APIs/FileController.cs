using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ClassifiedApp;
using Microsoft.AspNet.Identity;
using FlowJs;
using System.Linq;
using FlowJs.Interface;
using ClassifiedApp.Models;
using ClassifiedApp.DAL;

namespace MyProject.Controllers
{
    [Authorize]
    [RoutePrefix("api/File")]
    public class FileController : ApiController
    {
        private readonly IFlowJsRepo _flowJs;
        

        public FileController()
        {
            _flowJs = new FlowJsRepo();
        }

        string Folder = @"/PicUpload"; //HttpContext.Current.Server.MapPath("~/PicUpload").Replace(HttpContext.Current.Request.PhysicalApplicationPath,String.Empty);

        [HttpGet]
        [Route("Upload")]
        public async Task<IHttpActionResult> PictureUploadGet()
        {
            var request = HttpContext.Current.Request;

            var chunkExists = _flowJs.ChunkExists(Folder, request);
            if (chunkExists) return Ok();
            return NotFound();
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IHttpActionResult> PictureUploadPost()
        {
            var request = HttpContext.Current.Request;
            
            var validationRules = new FlowValidationRules();
            validationRules.AcceptedExtensions.AddRange(new List<string> { "jpeg", "jpg", "png", "bmp" });
            validationRules.MaxFileSize = 5000000;

            try
            {
                var status = _flowJs.PostChunk(request, Folder, validationRules);
    
                if (status.Status == PostChunkStatus.Done)
                {
                    
                    #region Amazon S3
                    // file uploade is complete. Below is an example of further file handling
                    //var filePath = Path.Combine(Folder, status.FileName);
                    //var file = File.ReadAllBytes(filePath);
                    //var picture = await _fileManager.UploadPictureToS3(User.Identity.GetUserId(), file, status.FileName);
                    //File.Delete(filePath);
                    //return Ok(file);
                    #endregion
                    var filePath = Path.Combine(Folder, status.FileName);
                    var file = File.ReadAllBytes(filePath);
                    var enhancedIdentifier = status.Identifier.Substring(0, 5) + Math.Ceiling((DateTime.Now - DateTime.MinValue).TotalMilliseconds);

                    Image image;
                    using (ClassifiedContext _db = new ClassifiedContext())
                    {
                        
                        if (_db.Images.Where(i => i.Identifier == enhancedIdentifier).FirstOrDefault() != null)
                            return Ok("Already Exist!");

                        image = new Image();
                        image.Path = filePath;
                        image.Identifier = enhancedIdentifier;
                        _db.Images.Add(image);
                        _db.SaveChanges();
                    }
                    
                    return Ok(image.Identifier);
                }
    
                if (status.Status == PostChunkStatus.PartlyDone)
                {
                    return Ok();
                }
    
                status.ErrorMessages.ForEach(x => ModelState.AddModelError("file", x));
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                ModelState.AddModelError("file", "exception");
                return BadRequest(ModelState);
            }
        }
    }
}
