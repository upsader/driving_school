using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public TrainingCategory TrainingCategory { get; set; }
        public int TrainingCategoryId { get; set; }
        public Mark? Mark { get; set; }
        public int? MarkId { get; set; }
        public ExamType ExamType { get; set; }
        public DateTime StartDate { get; set; }
    }

    
}
