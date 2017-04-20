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
    [RoutePrefix("api/admin/storage")]
    public class AdminUserStorageController : ApiController
    {
        private readonly IStorageFolderService _storageFolderService;

        public AdminUserStorageController(IStorageFolderService storageFolderService)
        {
            _storageFolderService = storageFolderService;
        }

        
        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetStorageFolders()
        {
            int creatorId = 1; //TODO User id
           return Ok(await _storageFolderService.GetStorageFoldersAsync(creatorId));
        }

        //[Route("{id:int}/modules")]
        //[HttpGet]
        //public async Task<IHttpActionResult> GetModules(int id)
        //{
        //    return Ok(await _moduleService.GetCourseModules(id));
        //}

        //[Route("")]
        //[HttpPost]
        //public async Task<IHttpActionResult> Post(CourseDTO course)
        //{
        //    return Ok(await _courseService.Add(course));
        //}
    }
}
