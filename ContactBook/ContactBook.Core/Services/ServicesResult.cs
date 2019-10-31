using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.Services
{
    public class ServicesResult
    {
        public ServicesResult(int id, bool succeeded)
        {
            Id = id;
            Succeeded = succeeded;
        }
        public ServicesResult(bool succeeded)
        {
            Succeeded = succeeded;
        }
        public ServicesResult(IEnumerable<string> errors)
        {
            Set(errors);
        }
        public int Id { get; }
        public IEntity Entity { get; private set; }
        public bool Succeeded { get; private set; }
        private List<string> errors = new List<string>();
        public ServicesResult Add(IEnumerable<string> errors)
        {
            foreach (string err in errors)
            {
                if (!string.IsNullOrEmpty(err))
                    this.errors.Add(err);
            }
            return this;
        }
        public ServicesResult Set(IEnumerable<string> errors)
        {
            this.errors.Clear();
            Add(errors);
            return this;
        }
        public ServicesResult Set(params string[] errors)
        {
            this.errors.Clear();
            Add(errors);
            return this;
        }
        public ServicesResult Set(bool success)
        {
            Succeeded = success;
            return this;
        }
        public ServicesResult Set(IEntity entity)
        {
            Entity = entity;
            return this;
        }
    }
}
