using System.ComponentModel.DataAnnotations;

namespace AspLesson10._2.Models
{
    public class Email
    {
        [EmailAddress]
        [Required]
        public string Receiver { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]  
        public string Body { get; set; }
    }
}
