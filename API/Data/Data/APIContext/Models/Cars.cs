using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Data.APIContext.Models
{
    public partial class Cars
    {
        public Cars()
        {
        }

        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string Frame { get; set; }
        public string Model { get; set; }
        public string Enrollment { get; set; }
        public DateTime Deadline { get; set; }
    }
}
