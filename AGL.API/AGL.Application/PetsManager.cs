using AGL.Entities;
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

        public string Url { get; set; }        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="petsRepository">The injected pets repository</param>
        public PetsManager(IPetsRepository petsRepository)
        {
            _petsRepository = petsRepository ?? throw new ArgumentNullException(nameof(petsRepository));
        }

        public void Dispose()
        {
        }

        /// <summary>
        /// Get Pets by Person's gender
        /// </summary>
        /// <param name="petType">The Pet type</param>
        /// <remarks>Throws ArgumentNullException</remarks>
        /// <returns><see cref="Task{PetsByPersonGenderCollection}"/></returns>
        public async Task<PetsByPersonGenderCollection> GetPetsByPersonGender(PetType petType)
        {
            var persons = await _petsRepository.GetPersonAndPets();

            //LINQ Query to get Pets by Person's gender and Pet type
            return new PetsByPersonGenderCollection()
            {
                PetsByPersonGender = persons.ToList()
                                           .Where(person => person.Pets != null)
                                           .GroupBy(person => person.Gender)
                                           .Select(g => new PetsByPersonGender
                                           {
                                               Gender = g.Key,
                                               Pets = g.SelectMany(person => person.Pets.Where(pet => pet.Type == petType)).OrderBy(x => x.Name)
                                           }).ToList()
            };
        }
    }
}
