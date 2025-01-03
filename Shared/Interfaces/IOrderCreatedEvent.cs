﻿using MassTransit;
using System;
using System.Collections.Generic;

namespace Shared.Interfaces
{
    public interface IOrderCreatedEvent : CorrelatedBy<Guid>
    {
        List<OrderItemMessage> OrderItems { get; set; }
    }
}
