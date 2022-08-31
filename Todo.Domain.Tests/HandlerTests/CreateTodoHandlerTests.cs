using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_execucao()
        {
            var command = new CreateTodoCommand("", "", DateTime.Now);
            var handler = new TodoHandler(new FakeTodoRepository());
            var result = (GenericCommandResult)handler.Handle(command);
            Assert.AreEqual(result.Success, false);
        }


        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_tarefa()
        {
            var command = new CreateTodoCommand("Titulo da Tarefa", "João", DateTime.Now);
            var handler = new TodoHandler(new FakeTodoRepository());
            var result = (GenericCommandResult)handler.Handle(command);
            Assert.AreEqual(result.Success, true);
        }
    }
}
