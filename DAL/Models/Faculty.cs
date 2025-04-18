using System.Collections.Generic;

namespace ProjectArchitecture.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
