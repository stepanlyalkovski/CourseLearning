using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CourseLearning.Web.Configuration
{
    public class CourseLearningConfiguration
    {
        public static string CourseLearningWebApiUrl => ConfigurationManager.AppSettings["CourseLearningWebApiUrl"];
    }
}