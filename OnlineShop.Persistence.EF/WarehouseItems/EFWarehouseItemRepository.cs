using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.WarehouseItems.Contracts;

namespace OnlineShop.Persistence.EF.WarehouseItems
{
    public class EFWarehouseItemRepository : WarehouseItemRepository
    {
        private readonly EFDataContext _context;
        public EFWarehouseItemRepository(EFDataContext context)
        {
            _context = context;
        }

        public async Task<WarehouseItem> FindById(int id)
        {
            return await _context.WarehouseItems.Include(_ => _.Product)
                .SingleOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<WarehouseItem> FindByProductId(int productId)
        {
            return await _context.WarehouseItems.Include(_ => _.Product)
                .SingleOrDefaultAsync(_ => _.ProductId == productId);
        }

        public async Task<bool> IsWarehouseItemExistsById(int id)
        {
            return await _context.WarehouseItems.AnyAsync(_ => _.Id == id);
        }

        public async Task<IList<GetWarehouseItemDto>> GetWarehouseItems(FilterModelDto filter)
        {
            var warehouseItemDtos = GetFilteredPage(filter);
            warehouseItemDtos = SortWarehouseItems(warehouseItemDtos, filter.IsAscending);

            return await warehouseItemDtos.ToListAsync();
        }

        private IQueryable<GetWarehouseItemDto> GetFilteredPage(FilterModelDto filter)
        {
            return _context.WarehouseItems.Where(warehouseItem =>
                warehouseItem.Product.Title.Contains(filter.Term ?? String.Empty) ||
                 warehouseItem.Product.ProductCode.Contains(filter.Term ?? string.Empty))
                 .Skip((filter.Page - 1) * filter.Limit).Take(filter.Limit)
                 .Select(_ => new GetWarehouseItemDto
                 {
                     Id = _.Id,
                     Stock = _.Stock,
                     ProductId = _.ProductId,
                     ProductTitle = _.Product.Title,
                     ProductCode = _.Product.ProductCode,
                     MinimumStock = _.Product.MinimumStock,
                     ProductCategoryId = _.Product.ProductCategoryId,

                     Status = _.Product.MinimumStock == _.Stock ? 
                        "Ready to purchase" : _.Stock == 0 ?
                            "Out of stock" : "Up for sale"
                 });
        }

        private IQueryable<GetWarehouseItemDto> SortWarehouseItems(IQueryable<GetWarehouseItemDto> warehouseItemDtos, bool isAscending)
        {
            if (isAscending)
                warehouseItemDtos = warehouseItemDtos.OrderBy(_ => _.ProductTitle).ThenBy(_ => _.Id);
            else
                warehouseItemDtos = warehouseItemDtos.OrderByDescending(_ => _.ProductTitle).ThenBy(_ => _.Id);

            return warehouseItemDtos;
        }
    }
}