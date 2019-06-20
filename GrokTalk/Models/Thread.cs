using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrokTalk.Models
{
    public class Thread
    {
        public long Id { get; set; }
        public DateTime ExecutionDate { get; set; }
        [Required(ErrorMessage = "Please enter correct info"), MinLength(2), MaxLength(50)]
        public string Subject { get; set; }       
    }
}
