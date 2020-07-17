using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tandem.DataAccess;

namespace Tandem.Application.User.Queries
{
    public class GetUsersQuery : IRequest<List<UserVm>>
    {
        public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserVm>>
        {
            private readonly IUserService _userService;
            private readonly IMapper _mapper;

            public GetUsersQueryHandler(IUserService userService, IMapper mapper)
            {
                _userService = userService;
                _mapper = mapper;
            }

            public async Task<List<UserVm>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                var response = await _userService.GetUsersAsync();
                var viewModel = _mapper.Map<List<UserVm>>(response);

                return await Task.FromResult(viewModel);
            }
        }
    }
}
