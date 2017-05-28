using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using CourseLearning.Application.Interface;
using CourseLearning.Model.DTO;
using CourseLearning.WebAPI.Extensions;
using Newtonsoft.Json;

namespace CourseLearning.WebAPI.Controllers.AdminControllers
{
    [RoutePrefix("api/admin/file")]
    public class AdminFileController : ApiController
    {
        private readonly IResourceService _resourceService;

        public AdminFileController(IResourceService resourceService)
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
                var storageResource =
                    JsonConvert.DeserializeObject<StorageResourceDTO>(provider.FormData["storageResource"]);
                var createdResource = new StorageResourceDTO
                {
                    Name = storageResource.Name,
                    Path = provider.FileData.First().LocalFileName,
                    StorageFolderId = storageResource.StorageFolderId,
                    MimeType = provider.FileData.First().Headers.ContentType.ToString()
                };

                var newResource = await _resourceService.AddResource(createdResource);
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

                return Created(Request.RequestUri + $"/{newResource.StorageResourceId}", newResource);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("{fileId:int}")]
        [HttpGet]
        public async Task<HttpResponseMessage> DownloadFile(int fileId)
        {
            var resource = await _resourceService.Get(fileId);
            var resourceFileStream = new ResourceFileStream(resource.Path);
            var response = Request.CreateResponse();

            if (resource.MimeType.Contains("image"))
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                var contents = File.ReadAllBytes(resource.Path);
                result.Content = new ByteArrayContent(contents);
                result.Content.Headers.ContentType = new MediaTypeHeaderValue(resource.MimeType);
                return result;
            }


            if (resource.MimeType.Contains("video") || resource.MimeType.Contains("audio"))
            {
                response.Content = new PushStreamContent(resourceFileStream.WriteToVideoStream, new MediaTypeHeaderValue(resource.MimeType));
            }

            return response;
        }

    }

    public class ResourceFileStream
    {
        private readonly string _fileName;

        public ResourceFileStream(string fileName)
        {
            _fileName = fileName;
        }

        public async Task WriteToVideoStream(Stream outputStream, HttpContent content, TransportContext context)
        {
            string videoFileName = _fileName;
            try
            {
                var buffer = new byte[65536];

                using (var video = File.Open(videoFileName, FileMode.Open, FileAccess.Read))
                {
                    var length = (int)video.Length;
                    var bytesRead = 1;

                    while (length > 0 && bytesRead > 0)
                    {
                        bytesRead = video.Read(buffer, 0, Math.Min(length, buffer.Length));
                        await outputStream.WriteAsync(buffer, 0, bytesRead);
                        length -= bytesRead;
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                outputStream.Close();
            }
        }

    }
}
