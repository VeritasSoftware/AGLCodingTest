using AGL.Application;
using AGL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AGL.API.Controllers
{
    /// <summary>
    /// Pets controller
    /// </summary>
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetsManager _petsManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="petsManager">The injected pets manager</param>
        public PetsController(IPetsManager petsManager)
        {
            _petsManager = petsManager ?? throw new ArgumentNullException(nameof(petsManager));
        }

        /// <summary>
        /// Get pets by person gender endpoint
        /// </summary>
        /// <param name="petType">The pet type</param>
        /// <returns><see cref="Task{IActionResult}"/></returns>
        [HttpGet("petsbypersongender/{petType}")]
        public async Task<IActionResult> GetPetsByPersonGender(PetType petType)
        {
            return Ok(await _petsManager.GetPetsByPersonGender(petType));
        }        
    }
}
