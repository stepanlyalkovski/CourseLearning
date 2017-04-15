using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CourseLearning.Application.Interface;
using CourseLearning.Model.DTO;

namespace CourseLearning.WebAPI.Controllers.AdminControllers
{
    [RoutePrefix("api/admin/folder")]
    public class StorageFolderController : ApiController
    {
        private readonly IStorageFolderService _storageFolderService;

        public StorageFolderController(IStorageFolderService storageFolderService)
        {
            _storageFolderService = storageFolderService;
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetFolder(int id)
        {
            return Ok(await _storageFolderService.Get(id, true));
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(StorageFolderDTO storageFolder)
        {
            return Ok(await _storageFolderService.Add(storageFolder));
        }
    }
}
