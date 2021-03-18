using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.Products.Contracts;
using OnlineShop.Services.Products.Exceptions;

namespace OnlineShop.Services.Products
{
    public class ProductAppService : ProductService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductRepository _repository;
        public ProductAppService(UnitOfWork unitOfWork, ProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = productRepository;
        }

        public async Task<int> Add(AddProductDto addProductDto)
        {
            ThrowExceptionIfProductCodeIsAlreadyExists(addProductDto.ProductCode);
            ThrowExceptionIfProductTitleIsAlreadyExistsInProductCategory(addProductDto.Title);

            var product = new Product
            {
                Title = addProductDto.Title,
                MinimumStock = addProductDto.MinimumStock,
                ProductCode = addProductDto.ProductCode,
                ProductCategoryId = addProductDto.ProductCategoryId
            };

            var warehouseItems = new HashSet<WarehouseItem>
            {
                new WarehouseItem
                {
                    ProductId = product.Id 
                }
            };
            product.WarehouseItems = warehouseItems;

            _repository.Add(product);
            await _unitOfWork.CompleteAsync();

            return product.Id;
        }

        public async Task<GetProductDto> GetById(int id)
        { 
            var product = await _repository.FindById(id);
            ThrowExceptionIfProductNotExists(product, id);

            var getProductDto = new GetProductDto
            {
                Id = product.Id,
                Title = product.Title,
                MinimumStock = product.MinimumStock,
                ProductCode = product.ProductCode,
                ProductCategoryId = product.ProductCategoryId
            };

            return getProductDto;
        }

        private void ThrowExceptionIfProductNotExists(Product getProductDto, int id)
        {
            if (getProductDto == null)
            {
                throw new ProductNotExistsException
                {
                    Id = id 
                };
            }
        }

        private void ThrowExceptionIfProductCodeIsAlreadyExists(string productCode)
        {
            if (_repository.IsProductCodeExists(productCode))
            {
                throw new ProductCodeAlreadyExistsException
                {
                    ProductCode = productCode
                };
            }
        }

        private void ThrowExceptionIfProductTitleIsAlreadyExistsInProductCategory(string productTitle)
        {
            if (_repository.IsProductTitleExistsInProductCategory(productTitle))
            {
                throw new ProductTitleAlreadyExistsInProductCategory()
                {
                    ProductTitle = productTitle
                };
            }
        }

    }
}