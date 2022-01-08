using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tahaluf.Elearning.API.Data
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime createDate { get; set; }
        public string category {get; set;}
    }
}
