using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseLearning.Model.ContentStorage;
using CourseLearning.Model.Enrollments;

namespace CourseLearning.Model
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        [Index("UserEmail", IsUnique = true)]
        [MaxLength(50)]
        public string Email { get; set; }

        public IList<EnrollmentSession> EnrollmentSessions { get; set; }

        public UserStorage UserStorage { get; set; }
    }
}