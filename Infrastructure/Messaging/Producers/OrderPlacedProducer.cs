using Application.Interfaces;
using Domain.Events;
using MassTransit;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Messaging.Producers
{
    public class OrderPlacedProducer(ISendEndpointProvider sendEndpointProvider, IConfiguration cfg) : IOrderPlacedProducer
    {
        public async Task OrderPlacedSend(OrderPlacedEvent evento)
        {
            Console.WriteLine($"Enviando evento para a fila:{cfg["RabbitMQ:Queues:FCG_Catalog"]}");

            var endpoint = await sendEndpointProvider.GetSendEndpoint(
                    new Uri($"queue:{cfg["RabbitMQ:Queues:FCG_Catalog"]}"));

            await endpoint.Send(evento);
        }

    }
}
