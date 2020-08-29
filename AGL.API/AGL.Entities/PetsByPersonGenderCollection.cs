using System.Collections.Generic;

namespace AGL.Entities
{
    public class PetsByPersonGenderCollection
    {
        public PetType PetType { get; set; }
        public ICollection<PetsByPersonGender> PetsByPersonGender { get; set; }
    }
}
