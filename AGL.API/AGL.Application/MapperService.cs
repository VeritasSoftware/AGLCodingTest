using AGL.Entities;
using AGL.Models;
using AutoMapper;

namespace AGL.Application
{
    public interface IMapperService
    {
        PetsByPersonGenderCollectionModel Map(PetsByPersonGenderCollection petsByPersonGenderCollection);
    }

    public class MapperService : IMapperService
    {
        private readonly IMapper _mapper;

        public MapperService()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            _mapper = mapperConfig.CreateMapper();
        }

        public PetsByPersonGenderCollectionModel Map (PetsByPersonGenderCollection petsByPersonGenderCollection)
        {
            return _mapper.Map<PetsByPersonGenderCollection, PetsByPersonGenderCollectionModel>(petsByPersonGenderCollection);
        }
    }
}
