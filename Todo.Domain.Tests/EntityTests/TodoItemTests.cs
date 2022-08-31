using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _validTodoItem = new TodoItem("Titulo do TODO", DateTime.Now, "João");
        //private readonly TodoItem _invaliTodoItem = new TodoItem("", DateTime.Now, "João");

        [TestMethod]
        public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
        {
             
            Assert.AreEqual(_validTodoItem.Done, false);
        }
    }
}
