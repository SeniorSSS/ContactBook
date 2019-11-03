using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Services.Models
{
    public class EmailRequest
    {
        //public int ContactId { get; set; } tas ja vajag ContactId atdod FrontEndam

        public int Id { get; set; }
        public string Email { get; set; }

    }
}
