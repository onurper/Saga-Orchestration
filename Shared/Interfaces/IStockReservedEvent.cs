using MassTransit;
using System;
using System.Collections.Generic;

namespace Shared.Interfaces
{
    public interface IStockReservedEvent : CorrelatedBy<Guid>
    {
        public List<OrderItemMessage> OrderItems { get; set; }
    }
}