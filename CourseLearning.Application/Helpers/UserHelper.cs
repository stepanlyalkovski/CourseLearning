﻿using System;
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
        private static IUnitOfWork _unitOfWork;

        UserHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public static async Task<User> GetCurrentUser()
        {
            string email = HttpContext.Current.User.Identity.Name; 
            return await _unitOfWork.Users.GetAsync(email);
        }
    }
}
