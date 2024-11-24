using MassTransit;
using System;
using System.Collections.Generic;

namespace Shared.Interfaces
{
    public interface IPaymentFailedEvent : CorrelatedBy<Guid>
    {
        public List<OrderItemMessage> OrderItemMessages { get; set; }
        public string Message { get; set; }
    }
}