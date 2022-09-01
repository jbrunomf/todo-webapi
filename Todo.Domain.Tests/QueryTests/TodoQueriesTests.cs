using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        private List<TodoItem> _items;

        public TodoQueriesTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", DateTime.Now, "usuarioA"));
            _items.Add(new TodoItem("Tarefa 2", DateTime.Now, "usuarioB"));
            _items.Add(new TodoItem("Tarefa 3", DateTime.Now, "usuarioC"));
            _items.Add(new TodoItem("Tarefa 4", DateTime.Now, "João"));
            _items.Add(new TodoItem("Tarefa 5", DateTime.Now, "usuarioD"));
        }

        [TestMethod]
        public void Consulta_deve_retornar_tarefas_do_usuario()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("João"));
            Assert.AreEqual(1, result.Count());
        }
    }
}
