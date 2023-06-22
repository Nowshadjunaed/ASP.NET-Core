using Microsoft.AspNetCore.Mvc;

namespace API.Model
{
    [ModelBinder(typeof(CustomBinderAnimalDetails))]
    public class AnimalModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
