using AutoMapper;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.Products;
using E_Commerce.ServiceAbstraction;
using E_Commerce.Shared.DTO.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Service;

public class ProductService (IUnitOfWork unitOfWork,IMapper mapper) : IProductService
{
    public async Task<IEnumerable<BrandResponse>> GetBrandsAsync(CancellationToken cancellationToken = default)
    {
       var Brand=await unitOfWork.GetRepository<ProductBrand,int>().GetAllAsync(cancellationToken);
        return mapper.Map<IEnumerable<BrandResponse>>(Brand);
    }

    public async Task<ProductResponse?> GetByIdAsync(int Id, CancellationToken cancellationToken = default)
    {
       var product= await unitOfWork.GetRepository<Product,int>().GetByIdAsync(Id, cancellationToken);
        return mapper.Map<ProductResponse>(product);
    }

    public async Task<IEnumerable<ProductResponse>> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        var product = await unitOfWork.GetRepository<Product, int>().GetAllAsync(cancellationToken);
        return mapper.Map<IEnumerable<ProductResponse>>(product);
    }

    public async Task<IEnumerable<TypeResponse>> GetTypesAsync(CancellationToken cancellationToken = default)
    {
        var Type = await unitOfWork.GetRepository<ProductType, int>().GetAllAsync(cancellationToken);
        return mapper.Map<IEnumerable<TypeResponse>>(Type);
    }
}
