using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.ProductCategories.Contracts;
using OnlineShop.Services.ProductCategories.Exceptions;
using OnlineShop.Services.Products.Contracts;
using OnlineShop.Services.Products.Exceptions;

namespace OnlineShop.Services.Products
{
    public class ProductAppService : ProductService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductRepository _repository;
        private readonly ProductCategoryRepository _productCategoryRepository;
        public ProductAppService(UnitOfWork unitOfWork, 
                                 ProductRepository productRepository,
                                 ProductCategoryRepository productCategoryRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = productRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<int> Add(AddProductDto addProductDto)
        {
            ThrowExceptionIfProductCodeIsAlreadyExists(addProductDto.ProductCode);
            ThrowExceptionIfProductTitleIsAlreadyExistsInProductCategory(addProductDto.Title);
            await ThrowExceptionIfProductCategoryNotExists(addProductDto.ProductCategoryId);

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

        private async Task ThrowExceptionIfProductCategoryNotExists(int productCategoryId)
        {
            if (!await _productCategoryRepository.IsProductCategoryExists(productCategoryId))
            {
                throw new ProductCategoryNotExistsException
                {
                    ProductCategoryId = productCategoryId
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
                    ProductId = id 
                };
            }
        }
    }
}