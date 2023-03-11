using MediatR;
using CleanArc.Application.Interfaces;
using CleanArc.Application.QueryProjections;
using CleanArc.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Queries.ActivityQueries
{
    public class ToDoQueryHandler : IRequestHandler<GetAllToDoQuery, GetAllToDoQueryResponse>,
        IRequestHandler<GetToDoByIdQuery, GetToDoByIdQueryResponse>
    {
        private readonly IRepository _repository;
        public ToDoQueryHandler(IRepository toDoRepository)
        {
            _repository = toDoRepository;
        }

        public async Task<GetAllToDoQueryResponse> Handle(GetAllToDoQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAllToDoQueryResponse();
            var todos = _repository.GetEntities<ToDo>().Where(x=> x.UserId == request.User.UserId).ToList();
            var toDosResponse = todos.Select(x => new ToDoProjection { Id = x.Id, Name = x.Name, Description = x.Description }).ToList();
            response.ToDoModels = toDosResponse;
            return response;
        }

        public async Task<GetToDoByIdQueryResponse> Handle(GetToDoByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new GetToDoByIdQueryResponse();
            var todo = _repository.GetEntities<ToDo>().Where(x=> x.Id == request.ToDoId && x.UserId == request.User.UserId).FirstOrDefault();
            var toDosResponse = new ToDoProjection { Id = todo.Id, Name = todo.Name, Description = todo.Description };
            response.ToDo = toDosResponse;
            return response;
        }
    }
}
