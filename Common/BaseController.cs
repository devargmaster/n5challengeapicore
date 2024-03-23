using System.Net.Mime;
using Common.GenericsMethods.Queries;
using Data.Models;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Common;

  [ApiController]
  [Route("api/[controller]")]
public class BaseController<T> : ControllerBase where T: BaseDomainEntity
{
    // utilizo mediator
    private readonly IMediator _mediator;
    

    public BaseController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<T>>> Get()
    {
        var response = await _mediator.Send(new GetQuery<T>());
        return Ok(response.Data.ToList());
    }
}