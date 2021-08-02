using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace ToysPayment.API.Models.Dto
{
    public class PaymentResponse
    {
        public decimal Point { get; set; }

        public decimal Discount { get; set; }
    }
}
