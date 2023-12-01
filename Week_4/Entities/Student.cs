using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_4.Common;

namespace Week_4.Entities
{
    public class Student: EntityBase
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; }
    }
}
