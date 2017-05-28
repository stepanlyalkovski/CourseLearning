using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CourseLearning.DAL.Interface;
using CourseLearning.Model;

namespace CourseLearning.Application.Helpers
{
    public class UserHelper
    {
        public static async Task<User> GetCurrentUser(IUnitOfWork unitOfWork)
        {
            string email = HttpContext.Current.User.Identity.Name; 
            return await unitOfWork.Users.GetAsync(email);
        }
    }
}
