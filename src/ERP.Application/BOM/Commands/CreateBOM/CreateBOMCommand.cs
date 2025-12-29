using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.BOM.Commands.CreateBOM
{
    public record CreateBOMCommand(
    Guid ProductId,
    byte Version,
    List<CreateBOMItem> Items
) : ICommand<Guid>;

    public record CreateBOMItem(
        Guid MaterialId,
        decimal Quantity,
        Guid UnitOfMeasureId,
        List<Guid> ApplyToAttributeValueIds
    );

}