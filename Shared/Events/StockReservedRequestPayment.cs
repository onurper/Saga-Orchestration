using Shared.Interfaces;
using System;
using System.Collections.Generic;

namespace Shared.Events
{
    public class StockReservedRequestPayment : IStockReservedRequestPayment
    {
        public PaymentMessage PaymentMessage { get; set; }

        public List<OrderItemMessage> OrderItemMessages { get; set; }

        public Guid CorrelationId { get; }

        public StockReservedRequestPayment(Guid correlationId)
        {
            CorrelationId = correlationId;
        }
    }
}