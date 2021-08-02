using System;
using System.ComponentModel.DataAnnotations;

namespace ToysPayment.API.Models.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; init; }
        public DateTime ModifiedDate { get; set; }
    }
}
