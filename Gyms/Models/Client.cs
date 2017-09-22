using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gyms.Models
{
    public class Client
    {
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [DisplayName("First Name")]
        [StringLength(100, MinimumLength = 1)]
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        [StringLength(100, MinimumLength = 1)]
        [Required]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the classes.
        /// </summary>
        /// <value>
        /// The classes.
        /// </value>
        [NotMapped]
        public List<Class> Classes { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        public Client()
        {
            this.Classes = new List<Class>();
        }

    }
}
