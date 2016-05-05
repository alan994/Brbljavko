using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brbljavko.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string AvatarUrl { get; set; }
        public string Nickname { get; set; }
        public DateTime LastSeen { get; set; }
    }
}
