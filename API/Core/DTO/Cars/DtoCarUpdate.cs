using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO.Usuarios
{
    public class DtoCarUpdate
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string Frame { get; set; }
        public string Model { get; set; }
        public string Enrollment { get; set; }
        public DateTime Deadline { get; set; }
    }
}
