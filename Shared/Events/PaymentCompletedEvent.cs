﻿using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class PaymentCompletedEvent : IPaymentCompletedEvent
    {
        public Guid CorrelationId { get; }

        public PaymentCompletedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }
    }
}