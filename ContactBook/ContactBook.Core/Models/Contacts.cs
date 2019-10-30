using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.Models
{
    public class Contacts : Entity
    {
        public string Name { get; set; }   
        public string Company { get; set; }
        public string Note { get; set; }
        public string Birthday { get; set; }
    }
}
