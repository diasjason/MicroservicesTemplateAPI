using AutoMapper;

namespace MicroservicesTemplateAPI.Application.Automapper
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
