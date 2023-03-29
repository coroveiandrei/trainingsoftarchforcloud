using MediatR;
using Newtonsoft.Json;
using DDDCqrsEs.Common.Identity;

namespace DDDCqrsEs.Application.Common
{
    public class BaseRequest<T> : IRequest<T>
    {
        [JsonIgnore]
        public CurrentUser User { get; set; }
    }
}
