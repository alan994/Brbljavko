using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brbljavko.Models
{
    public class Message
    {
        public string Text { get; set; }
        public DateTime SentAt { get; set; }
        public string SenderName { get; set; }
    }
}
