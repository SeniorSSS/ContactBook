using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.Models
{
    public class Addresses : Entity
    {
        public string Address { get; set; }
        public virtual Contacts Contact { get; set; }
    }
}
