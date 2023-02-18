using System.ComponentModel.DataAnnotations;
using Core.Entities.Identity;

namespace Core.Entities
{
    public class Address : BaseEntity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}