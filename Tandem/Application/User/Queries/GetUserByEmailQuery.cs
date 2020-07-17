using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tandem.Application.Common.AutoMapper;
using Tandem.Application.Common.Exceptions;
using Tandem.DataAccess;

namespace Tandem.Application.User.Queries
{
    public class GetUserByEmailQuery : IRequest<UserVm>
    {
        public string Email { get; set; }
    }

    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, UserVm>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetUserByEmailHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserVm> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var response = await _userService.GetUserByEmailAsync(request.Email);
            var viewModel = _mapper.Map<UserVm>(response);

            if (viewModel == null)
            {
                throw new NotFoundException(nameof(User), request.Email);
            }

            return await Task.FromResult(viewModel);
        }
    }
}
