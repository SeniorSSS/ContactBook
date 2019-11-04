using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.Services
{
    public class Result
    {
        public bool Succeeded { get; private set; }
        public string Response { get; set; }

        public Result(bool succeeded)
        {
            Succeeded = succeeded;
        }

        public Result(bool succeeded, string response)
        {
            Succeeded = succeeded;
            Response = response;
        }
    }
}
