using AutoMapper;

namespace MicroservicesTemplate.Common.Automapper
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
