using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MyFavoriteMotobike.ModelBinders
{
    public class DecimalModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(decimal) 
                || context.Metadata.ModelType == typeof(decimal?))
            {
                return new DecimalModelBinder();
            }

            if (context.Metadata.ModelType == typeof(float)
                || context.Metadata.ModelType == typeof(float?))
            {
                return new DecimalModelBinder();
            }

            if (context.Metadata.ModelType == typeof(double)
                || context.Metadata.ModelType == typeof(double?))
            {
                return new DecimalModelBinder();
            }

            return null;
        }
    }
}
