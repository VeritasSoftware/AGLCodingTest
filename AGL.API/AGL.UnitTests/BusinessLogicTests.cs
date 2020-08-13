using AGL.Application;
using AGL.Entities;
using AGL.Repository;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AGL.UnitTests
{
    /// <summary>
    /// Test business logic. Using NSubstitute for mocking the repository.
    /// </summary>
    public class BusinessLogicTests
    {
        [Fact]
        public void Test_GetPetsByPersonGender()
        {            
            var personAndPets = new Person[] 
            {
                new Person
                {
                    Name = "Bob",
                    Gender = Gender.Male,
                    Age = 23,
                    Pets = new List<Pet>
                    {
                        new Pet
                        {
                            Name = "Garfield",
                            Type = PetType.Cat
                        },
                        new Pet
                        {
                            Name = "Fido",
                            Type = PetType.Dog
                        }
                    }
                },
                new Person
                {
                    Name = "Jennifer",
                    Gender = Gender.Female,
                    Age = 18,
                    Pets = new List<Pet>
                    {
                        new Pet
                        {
                            Name = "Garfield",
                            Type = PetType.Cat
                        }
                    }
                },
                new Person
                {
                    Name = "Steve",
                    Gender = Gender.Male,
                    Age = 45,
                    Pets = null
                },
                new Person
                {
                    Name = "Fred",
                    Gender = Gender.Male,
                    Age = 40,
                    Pets = new List<Pet>
                    {
                        new Pet
                        {
                            Name = "Tom",
                            Type = PetType.Cat
                        },
                        new Pet
                        {
                            Name = "Max",
                            Type = PetType.Cat
                        },
                        new Pet
                        {
                            Name = "Sam",
                            Type = PetType.Dog
                        },
                        new Pet
                        {
                            Name = "Jim",
                            Type = PetType.Cat
                        }
                    }
                },
                new Person
                {
                    Name = "Samantha",
                    Gender = Gender.Female,
                    Age = 40,
                    Pets = new List<Pet>
                    {
                        new Pet
                        {
                            Name = "Tabby",
                            Type = PetType.Cat
                        }
                    }
                },
                new Person
                {
                    Name = "Alice",
                    Gender = Gender.Female,
                    Age = 64,
                    Pets = new List<Pet>
                    {
                        new Pet
                        {
                            Name = "Simba",
                            Type = PetType.Cat
                        },
                        new Pet
                        {
                            Name = "Nemo",
                            Type = PetType.Fish
                        }
                    }
                },
            };

            //Use NSubstitue to mock the repository layer
            var petsRepository = Substitute.For<IPetsRepository>();
            petsRepository.GetPersonAndPets().Returns(personAndPets);

            //Create PetsManager instance
            IPetsManager petsManager = new PetsManager(petsRepository);

            //Call method to be tested. This method contains the business logic.
            var catsByPersonGender = petsManager.GetPetsByPersonGender(PetType.Cat).Result;            

            //Check that there are 2 genders in the collection
            Assert.True(catsByPersonGender.PetsByPersonGender.Count == 2);

            //Check Cats belonging to Male persons - alphabetically ordered
            Assert.True(catsByPersonGender.PetsByPersonGender.First().Gender == Gender.Male);
            Assert.True(catsByPersonGender.PetsByPersonGender.First().Pets.Count() == 4);
            Assert.True(catsByPersonGender.PetsByPersonGender.First().Pets.ElementAt(0).Name == "Garfield");
            Assert.True(catsByPersonGender.PetsByPersonGender.First().Pets.ElementAt(1).Name == "Jim");
            Assert.True(catsByPersonGender.PetsByPersonGender.First().Pets.ElementAt(2).Name == "Max");
            Assert.True(catsByPersonGender.PetsByPersonGender.First().Pets.ElementAt(3).Name == "Tom");

            //Check Cats belonging to Female persons - alphabetically ordered
            Assert.True(catsByPersonGender.PetsByPersonGender.Last().Gender == Gender.Female);
            Assert.True(catsByPersonGender.PetsByPersonGender.Last().Pets.Count() == 3);
            Assert.True(catsByPersonGender.PetsByPersonGender.Last().Pets.ElementAt(0).Name == "Garfield");
            Assert.True(catsByPersonGender.PetsByPersonGender.Last().Pets.ElementAt(1).Name == "Simba");
            Assert.True(catsByPersonGender.PetsByPersonGender.Last().Pets.ElementAt(2).Name == "Tabby");
        }
    }
}
