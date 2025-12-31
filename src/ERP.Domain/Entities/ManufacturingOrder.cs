using ERP.Domain.Enums;
using ERP.Domain.Primitives;

namespace ERP.Domain.Entities
{
    public class ManufacturingOrder : Entity
    {
        public ManufacturingOrder(Guid id) : base(id) { }
        public string Code { get; set; }
        public Guid RoutingId { get; set; }
        public Routing Routing { get; set; }
        public decimal QuantityToProduce { get; set; }
        public decimal QuantityProduced { get; set; }
        public ManufacturingOrderStatus ManufacturingOrderStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        private ManufacturingOrder(Guid id, string code, Guid routingId, decimal quantityToProduce, decimal quantityProduced, ManufacturingOrderStatus manufacturingOrderStatus, DateTime startDate, DateTime endDate) : base(id)
        {
            Code = code;
            RoutingId = routingId;
            QuantityToProduce = quantityToProduce;
            QuantityProduced = quantityProduced;
            ManufacturingOrderStatus = manufacturingOrderStatus;
            StartDate = startDate;
            EndDate = endDate;
        }
        public static ManufacturingOrder Create(string code, Guid routingId, decimal quantityToProduce, decimal quantityProduced, ManufacturingOrderStatus manufacturingOrderStatus, DateTime startDate, DateTime endDate)
        {
            return new ManufacturingOrder(Guid.NewGuid(), code, routingId, quantityToProduce, quantityProduced, manufacturingOrderStatus, startDate, endDate);
        }

        public void Update(string code, Guid routingId, decimal quantityToProduce, DateTime startDate, DateTime endDate)
        {
            Code = code;
            RoutingId = routingId;
            QuantityToProduce = quantityToProduce;
            StartDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
            EndDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);
        }
    }
}
