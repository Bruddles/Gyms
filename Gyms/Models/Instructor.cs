using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gyms.Models
{
    public class Instructor
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
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
    }
}
