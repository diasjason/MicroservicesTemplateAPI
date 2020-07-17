using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tandem.Application.Common.AutoMapper;
using Tandem.DataAccess;

namespace Tandem.Application.User.Commands
{
    public class CreateUserCommand : IRequest<bool>, IMapFrom<Domain.Entities.User>
    {
        public string FirstName { get; set; }
        public string MiddelName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserCommand, Domain.Entities.User>(MemberList.Source)
                .ForMember(d => d.Id, opt => opt.MapFrom(s => Guid.NewGuid().ToString()));
        }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Domain.Entities.User>(request);

            return await _userService.PostUser(user);
        }
    }
}
