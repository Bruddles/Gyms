﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace Gyms.Models
{
    public class Class
    {
        [Column("Duration")]
        private double _durationTicks;

        public int ID { get; set; }

        public int InstructorID { get; set; }

        public Instructor Instructor { get; set; }
        
        public DateTime Date { get; set; }

        [NotMapped]
        public Duration Duration
        {
            get => Duration.FromTicks(_durationTicks);
            set => _durationTicks = value.TotalTicks;
        }

        public string Name { get; set; }

        public List<ClassAttendance> ClassAttendance { get; set; }
        
    }
}
