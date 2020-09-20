using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CatalogApplication.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CatalogApplication.Commands;

namespace CatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetAllProducts()));

        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromBody] AddProductCommand addProductCommand) => Ok(await _mediator.Send(addProductCommand));

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand updateProductCommand) => Ok(await _mediator.Send(updateProductCommand));

    }
}
