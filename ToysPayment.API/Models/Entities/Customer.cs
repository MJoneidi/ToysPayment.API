using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToysPayment.API.Models.Entities
{
    public class Customer : BaseEntity
    {
        [StringLength(256)]
        public string FirstName { get; set; }

        [StringLength(256)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get => $"{FirstName} {LastName}"; }
        public decimal Points { get; set; }

        public decimal TotalBuy { get; set; }
    }
}
