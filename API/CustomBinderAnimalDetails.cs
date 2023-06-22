using API.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection;

namespace API
{
    public class CustomBinderAnimalDetails : IModelBinder
    {
        
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelName = bindingContext.ModelName;
            var value = bindingContext.ValueProvider.GetValue(modelName);
            var result = value.FirstValue;

            if(!int.TryParse(result, out var id))
            {
                return Task.CompletedTask;
            }

            var model = new AnimalModel()
            {
                Id = id,
                Name = "Lion"
            };

            bindingContext.Result = ModelBindingResult.Success(model);

            return Task.CompletedTask;
        }
    }
}
