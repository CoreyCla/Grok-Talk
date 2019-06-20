using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrokTalk.Models
{
    public class Message
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public DateTime ExecutionDate { get; set; }
        [Required(ErrorMessage = "Please enter correct info"), MinLength(2), MaxLength(50)]
        public string From { get; set; }
        public bool Priority { get; set; }
        [Required(ErrorMessage = "Please enter correct info"), MinLength(4), MaxLength(250)]
        public string Body { get; set; }       
    }
}
