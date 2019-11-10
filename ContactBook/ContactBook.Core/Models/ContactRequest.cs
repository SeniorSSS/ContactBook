using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.Models
{
    public class ContactRequest : IEquatable<ContactRequest>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Equals(ContactRequest other)
        {
            if (other is null)
                return false;

            return this.Name == other.Name && this.Id == other.Id;
        }

        public override bool Equals(object obj) => Equals(obj as ContactRequest);

        public override int GetHashCode() => (Id, Name).GetHashCode();
    }
}