using ERP.Domain.Entities;
using ERP.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.API.Controllers
{
    public class SeedController : BaseApiController
    {
        private readonly AppDbContext _dbContext;
        public SeedController(ISender mediator, AppDbContext appDbContext) : base(mediator)
        {
            _dbContext = appDbContext;
        }

        [HttpGet("/seed")]
        public async Task<IActionResult> Seed()
        {

            if (await _dbContext.Categories.AnyAsync())
                return Ok("Dữ liệu đã được seed trước đó");

            // Category
            // Cấp 1
            var catFurniture = new Category(Guid.NewGuid()) { Name = "Nội thất", Level = 1, SortOrder = 1 };
            var catDecor = new Category(Guid.NewGuid()) { Name = "Trang trí", Level = 1, SortOrder = 2 };
            var catLighting = new Category(Guid.NewGuid()) { Name = "Đèn chiếu sáng", Level = 1, SortOrder = 3 };
            var catOffice = new Category(Guid.NewGuid()) { Name = "Nội thất văn phòng", Level = 1, SortOrder = 4 };

            // Cấp 2
            var catSeating = new Category(Guid.NewGuid()) { Name = "Ghế ngồi", ParentId = catFurniture.Id, Level = 2, SortOrder = 1 };
            var catTable = new Category(Guid.NewGuid()) { Name = "Bàn", ParentId = catFurniture.Id, Level = 2, SortOrder = 2 };
            var catShelf = new Category(Guid.NewGuid()) { Name = "Tủ/Kệ", ParentId = catFurniture.Id, Level = 2, SortOrder = 3 };

            var catWallDecor = new Category(Guid.NewGuid()) { Name = "Trang trí tường", ParentId = catDecor.Id, Level = 2, SortOrder = 1 };
            var catFloorDecor = new Category(Guid.NewGuid()) { Name = "Trang trí sàn", ParentId = catDecor.Id, Level = 2, SortOrder = 2 };

            // Cấp 3
            var catDiningChair = new Category(Guid.NewGuid()) { Name = "Ghế ăn", ParentId = catSeating.Id, Level = 3, SortOrder = 1 };
            var catArmchair = new Category(Guid.NewGuid()) { Name = "Ghế bành", ParentId = catSeating.Id, Level = 3, SortOrder = 2 };
            var catSofa = new Category(Guid.NewGuid()) { Name = "Sofa", ParentId = catSeating.Id, Level = 3, SortOrder = 3 };

            var catCoffeeTable = new Category(Guid.NewGuid()) { Name = "Bàn trà", ParentId = catTable.Id, Level = 3, SortOrder = 1 };
            var catDiningTable = new Category(Guid.NewGuid()) { Name = "Bàn ăn", ParentId = catTable.Id, Level = 3, SortOrder = 2 };
            var catWorkDesk = new Category(Guid.NewGuid()) { Name = "Bàn làm việc", ParentId = catTable.Id, Level = 3, SortOrder = 3 };

            var categories = new List<Category>
            {
                catFurniture, catDecor, catLighting, catOffice,
                catSeating, catTable, catShelf,
                catWallDecor, catFloorDecor,
                catDiningChair, catArmchair, catSofa,
                catCoffeeTable, catDiningTable, catWorkDesk
            };

            await _dbContext.Categories.AddRangeAsync(categories);

            // Attribute
            var attrMaterial = new Domain.Entities.Attribute(Guid.NewGuid(), "Chất liệu");
            var attrColor = new Domain.Entities.Attribute(Guid.NewGuid(), "Màu sắc");
            var attrSize = new Domain.Entities.Attribute(Guid.NewGuid(), "Kích thước");
            var attrStyle = new Domain.Entities.Attribute(Guid.NewGuid(), "Phong cách");

            var attributes = new List<Domain.Entities.Attribute> { attrMaterial, attrColor, attrSize, attrStyle };
            await _dbContext.Attributes.AddRangeAsync(attributes);

            var attrValues = new List<AttributeValue>
            {
                // Material
                new AttributeValue(Guid.NewGuid()) { AttributeId = attrMaterial.Id, Value = "Gỗ" },
                new AttributeValue(Guid.NewGuid()) { AttributeId = attrMaterial.Id, Value = "Kim loại" },
                new AttributeValue(Guid.NewGuid()) { AttributeId = attrMaterial.Id, Value = "Nhựa" },
                new AttributeValue(Guid.NewGuid()) { AttributeId = attrMaterial.Id, Value = "Da" },

                // Color
                new AttributeValue(Guid.NewGuid()) { AttributeId = attrColor.Id, Value = "Trắng" },
                new AttributeValue(Guid.NewGuid()) { AttributeId = attrColor.Id, Value = "Đen" },
                new AttributeValue(Guid.NewGuid()) { AttributeId = attrColor.Id, Value = "Nâu" },
                new AttributeValue(Guid.NewGuid()) { AttributeId = attrColor.Id, Value = "Xám" },

                // Size
                new AttributeValue(Guid.NewGuid()) { AttributeId = attrSize.Id, Value = "Nhỏ" },
                new AttributeValue(Guid.NewGuid()) { AttributeId = attrSize.Id, Value = "Vừa" },
                new AttributeValue(Guid.NewGuid()) { AttributeId = attrSize.Id, Value = "Lớn" },

                // Style
                new AttributeValue(Guid.NewGuid()) { AttributeId = attrStyle.Id, Value = "Hiện đại" },
                new AttributeValue(Guid.NewGuid()) { AttributeId = attrStyle.Id, Value = "Cổ điển" },
                new AttributeValue(Guid.NewGuid()) { AttributeId = attrStyle.Id, Value = "Công nghiệp" },
            };


            await _dbContext.AttributeValues.AddRangeAsync(attrValues);

            var unitOfMeasures = new List<UnitOfMeasure>
            {
                new UnitOfMeasure(Guid.NewGuid(), "Cái"),
                new UnitOfMeasure(Guid.NewGuid(), "Bộ"),
                new UnitOfMeasure(Guid.NewGuid(), "Chiếc"),
                new UnitOfMeasure(Guid.NewGuid(), "Mét"),
                new UnitOfMeasure(Guid.NewGuid(), "Mét vuông"),
                new UnitOfMeasure(Guid.NewGuid(), "Kg"),
                new UnitOfMeasure(Guid.NewGuid(), "Gram"),
                new UnitOfMeasure(Guid.NewGuid(), "Lít")
            };

            await _dbContext.UnitOfMeasures.AddRangeAsync(unitOfMeasures);

            await _dbContext.SaveChangesAsync();

            return Ok("Seed dữ liệu thành công!");
        }
    }
}
