using AGL.Models;
using System;
using System.Threading.Tasks;

namespace AGL.Application
{
    /// <summary>
    /// Interface IPetsManager
    /// </summary>
    public interface IPetsManager : IDisposable
    {
        Task<PetsByPersonGenderCollectionModel> GetPetsByPersonGender(PetType petType);
    }
}
