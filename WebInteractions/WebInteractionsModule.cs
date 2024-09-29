using Autofac;
using Core.Web.BaseObjects;

namespace WebInteractions
{
    public class WebInteractionsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var webInteractionsTypes = AppDomain.CurrentDomain.GetAssemblies()
                .Single(assembly => assembly.GetName().Name == "WebInteractions")
                .GetTypes();

            webInteractionsTypes
                .Where(t => t.IsSubclassOf(typeof(BasePageObject)) || t.IsSubclassOf(typeof(BaseStepsObject)))
                .ToList()
                .ForEach(t => builder.RegisterType(t).AsSelf().PropertiesAutowired());
        }
    }
}
