using Microsoft.Extensions.Localization;
using DDDCqrsEs.Common;
using DDDCqrsEs.Common.Localization;
using DDDCqrsEs.WebUI;

namespace DDDCqrsEs.Infrastructure.Services
{
    [MapServiceDependency(nameof(i18nService))]
    public class i18nService : Ii18nService
    {
        private readonly IStringLocalizer _localizer;
        public i18nService(IStringLocalizer<Resources> localizer)
        {
            this._localizer = localizer;

        }

        public string GetMessage(string key)
        {
            var message = _localizer.GetString(key);
            return message.Value;
        }
    }
}

