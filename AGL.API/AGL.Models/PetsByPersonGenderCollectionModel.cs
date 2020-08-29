using System.Collections.Generic;

namespace AGL.Models
{
    public class PetsByPersonGenderCollectionModel
    {
        public PetType PetType { get; set; }
        public ICollection<PetsByPersonGenderModel> PetsByPersonGender { get; set; }
    }
}
