using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NodaTime;

namespace Gyms.Models
{
    public class Class
    {
        [Column("Duration")]
        private double _durationTicks;

        public int ID { get; set; }
        public Instructor Instructor { get; set; }

        [NotMapped]
        public List<Client> Clients { get; set; }

        public DateTime Date { get; set; }

        [NotMapped]
        public Duration Duration
        {
            get => Duration.FromTicks(_durationTicks);
            set => _durationTicks = value.TotalTicks;
        }

        public Class()
        {
            this.Clients = new List<Client>();
        }
    }
}
