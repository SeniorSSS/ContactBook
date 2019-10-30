using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.Models
{
    public class PhoneNumbers : Entity
    {
        public string PhoneNumber { get; set; }   
        public virtual PhoneTypes PhoneType { get; set; }
        public virtual Contacts Contact { get; set; }
    }
}
