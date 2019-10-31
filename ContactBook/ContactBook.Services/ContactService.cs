﻿using ContactBook.Core.Models;
using ContactBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Services
{
    public class ContactService : EntityService<Contacts>
    {
        public ContactService(IContactBookDbContext context) : base(context) { }
        public async Task<IEnumerable<Contacts>> GetFlights()
        {
            return await Task.FromResult(Get());
        }
    }
}