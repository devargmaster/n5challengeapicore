using Common;
using CoreWebApi.Models.Entities;
using MediatR;


namespace CoreWebApi.Controllers;

public class PermissionsController: BaseController<Permissions>
{
    public PermissionsController(IMediator mediator) : base(mediator)
    {
    }
}