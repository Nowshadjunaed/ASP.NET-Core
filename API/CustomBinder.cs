using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API
{
    public class CustomBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var data = bindingContext.HttpContext.Request.Query;
            

            var result = data.TryGetValue("animals", out var animal);

            if (result)
            {
                var array = animal.ToString().Split('|');
                bindingContext.Result = ModelBindingResult.Success(array);
            }

            return Task.CompletedTask;
            
        }
    }
}
