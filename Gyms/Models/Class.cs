using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace Gyms.Models
{
    public class Class
    {
        [Column("Duration")]
        private long _durationTicks;

        public int ID { get; set; }

        public int InstructorID { get; set; }

        public Instructor Instructor { get; set; }
        
        public DateTime Date { get; set; }

        [DataType(DataType.Duration)]
        public TimeSpan Duration
        {
            get => TimeSpan.FromTicks(_durationTicks);
            set => _durationTicks = value.Ticks;
        }

        public string Name { get; set; }

        public List<ClassAttendance> ClassAttendance { get; set; }
        
    }
}
