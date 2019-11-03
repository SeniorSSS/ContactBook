using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.Models
{
    public class PhoneRequest
    {
        public int Id { get; set; }
        public int PhoneTypeId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
