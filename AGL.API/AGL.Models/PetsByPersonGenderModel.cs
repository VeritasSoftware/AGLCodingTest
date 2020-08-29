using System.Collections.Generic;

namespace AGL.Models
{
    /// <summary>
    /// Class Pets By Person Gender
    /// </summary>
    public class PetsByPersonGenderModel
    {
        public Gender Gender { get; set; }

        public IEnumerable<PetModel> Pets { get; set; }
    }
}
