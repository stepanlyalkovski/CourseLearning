using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using CourseLearning.Application.Interface;
using CourseLearning.Model.DTO;
using CourseLearning.WebAPI.Extensions;
using Newtonsoft.Json;

namespace CourseLearning.WebAPI.Controllers.AdminControllers
{
    [RoutePrefix("api/admin/file")]
    public class FileController : ApiController
    {
        private readonly IResourceService _resourceService;

        public FileController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        
        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new CourseLearningMultipartFormDataProvider(root);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                var storageResource = JsonConvert.DeserializeObject<StorageResourceDTO>(provider.FormData["storageResource"]);
                var createdResource = new StorageResourceDTO
                {
                    Name = storageResource.Name,
                    Path = provider.FileData.First().LocalFileName,
                    StorageFolderId = storageResource.StorageFolderId,
                    MimeType = provider.FileData.First().Headers.ContentType.ToString()
                };
                int createdId = await _resourceService.Add(createdResource);
                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName); 
                    Trace.WriteLine("Server file type: " + file.Headers.ContentType);
                }

                // Show all the key-value pairs.
                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        Trace.WriteLine($"{key}: {val}");
                    }
                }

                return Created(Request.RequestUri + $"/{createdId}", new StorageResourceDTO { StorageResourceId = createdId });
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }


    }

}
