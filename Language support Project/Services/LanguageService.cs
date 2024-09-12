using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System.Reflection;

namespace Language_support_Project.Services
{

    public class SharedResource
    {

    }


    public class LanguageService
    {
        private readonly IStringLocalizer _localizer;

        public LanguageService( IStringLocalizerFactory factory)
        {
            var tytpe = typeof(SharedResource);

            var assemblyName = new AssemblyName(tytpe.GetTypeInfo().Assembly.FullName );

            _localizer = factory.Create(nameof(SharedResource), assemblyName.Name);


        
            
        
        }


        public LocalizedString GetKey ( string key)
        {
            return _localizer[key];
        }
    }
}
