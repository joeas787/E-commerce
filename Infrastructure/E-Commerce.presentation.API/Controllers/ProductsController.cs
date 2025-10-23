using E_Commerce.ServiceAbstraction;
using E_Commerce.Shared.DTO;
using E_Commerce.Shared.DTO.Products;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace E_Commerce.presentation.API.Controllers;

public class ProductsController(IProductService service)
    : APIBaseController
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<ProductResponse>>> GetProducts([FromQuery]ProductParameters parameters , CancellationToken cancellationToken = default)
    {

        var response = await service.GetProductsAsync( parameters, cancellationToken);

        return Ok(response);

    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse>> Get(int id,CancellationToken cancellationToken = default)
    {

        var response = await service.GetByIdAsync(id,cancellationToken);

        return Ok(response);

    }
    [HttpGet("Brands")]
    public async Task<ActionResult<IEnumerable<BrandResponse>>> GetBrands(CancellationToken cancellationToken = default)
    {

        var response = await service.GetBrandsAsync(cancellationToken);

        return Ok(response);

    }
    [HttpGet("Types")]
    public async Task<ActionResult<IEnumerable<TypeResponse>>> GetTypes(CancellationToken cancellationToken = default)
    {

        var response = await service.GetTypesAsync(cancellationToken);

        return Ok(response);

    }

}

