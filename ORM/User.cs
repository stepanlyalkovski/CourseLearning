using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ORM.ContentStorage;
using ORM.Enrollments;

namespace ORM
{
    public class User : DbEntity
    {
        [Key]
        [Column("UserId")]
        public override int Id { get; set; }

        public string Name { get; set; }

        public IList<EnrollmentSession> EnrollmentSessions { get; set; }

        public UserStorage UserStorage { get; set; }

    }
}