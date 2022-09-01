using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Subscriber.Data.Entities
{
    public class SubscriberEntity
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(15)]
        public string LastName { get; set; }
        [Required]
        [Index(IsUnique =true)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
