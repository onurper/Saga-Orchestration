﻿using MassTransit;
using Microsoft.Extensions.Logging;
using Shared;
using Shared.Events;
using Shared.Interfaces;
using System.Threading.Tasks;

namespace Payment.API.Consumers
{
    public class StockReservedRequestPaymentConsumer : IConsumer<IStockReservedRequestPayment>
    {
        private readonly ILogger<StockReservedRequestPaymentConsumer> _logger;

        private readonly IPublishEndpoint _publishEndpoint;

        public StockReservedRequestPaymentConsumer(ILogger<StockReservedRequestPaymentConsumer> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<IStockReservedRequestPayment> context)
        {
            var balance = 3000m;

            if (balance > context.Message.PaymentMessage.TotalPrice)
            {
                _logger.LogInformation($"{context.Message.PaymentMessage.TotalPrice} TL was withdrawn from credit card for user id= {context.Message.BuyerId}");

                await _publishEndpoint.Publish(new PaymentCompletedEvent(context.Message.CorrelationId));
            }
            else
            {
                _logger.LogInformation($"{context.Message.PaymentMessage.TotalPrice} TL was not withdrawn from credit card for user id={context.Message.BuyerId}");

                await _publishEndpoint.Publish(new PaymentFailedEvent(context.Message.CorrelationId));
            }
        }
    }
}