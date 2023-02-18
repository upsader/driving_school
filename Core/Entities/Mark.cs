using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Mark : BaseEntity
    {
        public int Value { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public TrainingCategory TrainingCategory { get; set; }
        public int TrainingCategoryId { get; set; }
    }
}
