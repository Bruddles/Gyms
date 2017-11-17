using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace Gyms.Models
{
    public class ClassViewModel
    {
        public Class Class { get; set; }

        public List<Client> Clients { get; set; }

    }
}
