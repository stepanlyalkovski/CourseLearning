using System.Collections.Generic;
using CourseLearning.Model.DTO.Enrollments;

namespace CourseLearning.Model.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public IList<EnrollmentSessionDTO> EnrollmentSessions { get; set; }

        public UserStorageDTO UserStorage { get; set; }

    }
}