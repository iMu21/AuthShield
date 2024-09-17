using MediatR;

namespace AuthShield.Application.Features.Auth.Query.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserVm>>
    {
    }
}
