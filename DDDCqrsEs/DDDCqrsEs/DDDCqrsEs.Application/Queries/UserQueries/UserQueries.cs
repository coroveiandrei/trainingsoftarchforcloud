using DDDCqrsEs.Application.Models.AuthenticationModels;
using DDDCqrsEs.Application.Common;
using System;

namespace DDDCqrsEs.Application.Queries.UserQueries
{
    public class GetUserDetailsQuery : BaseRequest<GetUserDetailsQueryResponse>
    {
        public Guid UserId { get; set; }
    }

    public class GetUserDetailsQueryResponse
    {
        public UserModel User { get; set; }
    }
}
