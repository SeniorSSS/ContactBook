using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.Models
{
    public class Companies : Entity
    {
        public string Company { get; set; }
        public virtual Contacts Contact { get; set; }
    }
}
