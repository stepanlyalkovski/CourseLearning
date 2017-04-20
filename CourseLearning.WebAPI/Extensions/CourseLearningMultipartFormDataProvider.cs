using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace CourseLearning.WebAPI.Extensions
{
    public class CourseLearningMultipartFormDataProvider : MultipartFormDataStreamProvider
    {
        public CourseLearningMultipartFormDataProvider(string rootPath) : base(rootPath)
        {
        }

        public CourseLearningMultipartFormDataProvider(string rootPath, int bufferSize) : base(rootPath, bufferSize)
        {
        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            //Make the file name URL safe and then use it & is the only disallowed url character allowed in a windows filename
            var name = Guid.NewGuid().ToString();

            if (!string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName))
            {
                var extension = Path.GetExtension(headers.ContentDisposition.FileName.Trim('"')).TrimStart('.');
                var invalidChars = Path.GetInvalidFileNameChars();

                name += "." + extension.Aggregate(string.Empty, (current, c) => current + (invalidChars.Contains(c) ? 'c' : c));
            }

            return name.Trim('"').Replace("&", "and");
        }

    }
}