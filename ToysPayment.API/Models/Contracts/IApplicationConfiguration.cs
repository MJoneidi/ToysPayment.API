using System.Collections.Generic;
using ToysPayment.API.Models.Enums;

namespace ToysPayment.API.Models.Contracts
{
    /// <summary>
    /// Abstraction to hide real source of configuration
    /// </summary>
    public interface IApplicationConfiguration
    {
        decimal MinTotalBuy { get; }
        decimal MaxDiscount { get; }
        Dictionary<MembershipType, CustomerMembership> MembershipsList { get; }
    }
}
