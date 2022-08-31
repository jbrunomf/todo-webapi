using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : Notifiable, IHandler<CreateTodoCommand>, IHandler<UpdateTodoCommand>, IHandler<MarkTodoAsDoneCommand>, IHandler<MarkTodoAsUndone>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
           command.Validate();
           if (command.Invalid)
           {
               return new GenericCommandResult(
                   false,
                   "Ops, verifique as informações da sua tarefa!",
                   command.Notifications);
           }
           var todo = new TodoItem(command.Title, command.Date, command.User);

           _repository.Create(todo);

           return new GenericCommandResult(true, "Tarefa Salva", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Tarefa inválida.", command);
            }

            var todo = _repository.GetById(command.Id, command.User);

            todo.UpdateTitle(command.Title);

            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa atualizada com sucesso.", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Verifique a sua tarefa!", command.Notifications);
            }


            var todo = _repository.GetById(command.Id, command.User);

            todo.MarksAsDone();

            return new GenericCommandResult(true, "Tarefa atualizada com sucesso!", todo);
        }

        public ICommandResult Handle(MarkTodoAsUndone command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "A sua tarefa está errada!", command.Notifications);
            }

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsUndone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa salva", command);
        }
    }
}
