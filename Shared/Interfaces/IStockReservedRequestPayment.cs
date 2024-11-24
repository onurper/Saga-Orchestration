using MassTransit;
using System;
using System.Collections.Generic;

namespace Shared.Interfaces
{
    public interface IStockReservedRequestPayment : CorrelatedBy<Guid>
    {
        public PaymentMessage PaymentMessage { get; }
        public List<OrderItemMessage> OrderItemMessages { get; set; }
    }
}