using CleanArc.Application.Common;
using CleanArc.Application.Models.AuthenticationModels;
using System;

namespace CleanArc.Application.Queries.UserQueries
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
