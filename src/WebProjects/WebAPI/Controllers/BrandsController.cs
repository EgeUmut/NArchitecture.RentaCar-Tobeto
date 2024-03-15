using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries;
using Application.Features.Brands.Queries.GetListDynamic;
using Application.Features.Brands.Queries.GetListPagination;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            return Created("", await Mediator.Send(new GetListBrandQuery()));
        }

        [HttpGet("GetListPagination")]
        public async Task<IActionResult> GetListPagination([FromQuery] PageRequest pageRequest)
        {
            GetListPaginayionBrandQuery query = new() { PageRequest = pageRequest };
            return Created("", await Mediator.Send(query));
        }

        [HttpPost("GetListDynamic")]
        public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest , [FromBody] Dynamic dynamic)
        {
            GetListBrandDynamicQuery dynamicQuery = new() { PageRequest = pageRequest ,Dynamic = dynamic};
            return Created("", await Mediator.Send(dynamicQuery));
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdBrandQuery query)
        {
            return Created("", await Mediator.Send(query));
        }
    }
}
