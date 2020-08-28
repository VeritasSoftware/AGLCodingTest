using AGL.Entities;
using AGL.Models;
using AGL.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AGL.Application
{
    /// <summary>
    /// Class PetsManager
    /// </summary>
    public class PetsManager : IPetsManager
    {
        private readonly Person[] _persons;
        private readonly IPetsRepository _petsRepository;
        private readonly IMapperService _mapperService;

        public string Url { get; set; }        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="petsRepository">The injected pets repository</param>
        public PetsManager(IPetsRepository petsRepository, IMapperService mapperService)
        {
            _petsRepository = petsRepository ?? throw new ArgumentNullException(nameof(petsRepository));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Dispose()
        {
        }

        /// <summary>
        /// Get Pets by Person's gender
        /// </summary>
        /// <param name="petType">The Pet type</param>
        /// <remarks>Throws ArgumentNullException</remarks>
        /// <returns><see cref="Task{PetsByPersonGenderCollectionModel}"/></returns>
        public async Task<PetsByPersonGenderCollectionModel> GetPetsByPersonGender(Models.PetType petType)
        {
            var entitiesPetType = (Entities.PetType)(int)petType;

            var persons = await _petsRepository.GetPersonAndPets();
            
            //LINQ Query to get Pets by Person's gender and Pet type
            var entities = new PetsByPersonGenderCollection()
            {
                PetsByPersonGender = persons.ToList()
                                           .Where(person => person.Pets != null)
                                           .GroupBy(person => person.Gender)
                                           .Select(g => new PetsByPersonGender
                                           {
                                               Gender = g.Key,
                                               PetType = entitiesPetType,
                                               Pets = g.SelectMany(person => person.Pets.Where(pet => pet.Type == entitiesPetType)).OrderBy(x => x.Name)
                                           }).ToList()
            };

            //Map entities to models
            var models = _mapperService.Map(entities);

            return models;
        }
    }
}
