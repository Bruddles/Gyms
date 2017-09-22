using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gyms.Models
{
    public class ClassAttendance
    {
        public int ClientId { get; set; }
        public int ClassId { get; set; }

        public Client Client { get; set; }
        public Class Class { get; set; }
    }
}
