using ERP.Application.Abstractions.Messaging;
using MediatR;

namespace ERP.Application.ManufacturingOrders.Queries.GetMOById
{
    public class GetMOByIdQuery(Guid ManufacturingOrderId) : IQuery<MOByIdResponse>
    {
        public Guid ManufacturingOrderId { get; } = ManufacturingOrderId;
    }
}