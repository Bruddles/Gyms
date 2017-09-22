using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gyms.Models
{
    public class Client
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        [NotMapped]
        public List<Class> Classes { get; set; }

        public Client()
        {
            this.Classes = new List<Class>();
        }

    }
}
