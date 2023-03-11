using MediatR;
using CleanArc.Application.Common;
using CleanArc.Application.Models;
using System;

namespace CleanArc.Application.Commands.ToDoCommands
{
    public class AddToDoCommand: BaseRequest<AddToDoCommandResponse>
    {
        public ToDoModel ToDo { get; set; }
    }

    public class EditToDoCommand: BaseRequest<EditToDoCommandResponse>
    {
        public ToDoModel ToDo { get; set; }
    }
    public class DeleteToDoCommand: BaseRequest<Unit>
    {
        public Guid Id { get; set; }

    }

    public class AddToDoCommandResponse
    {
        public Guid ToDoId { get; set; }
    }


    public class EditToDoCommandResponse
    {
        public Guid ToDoId { get; set; }
    }

}
