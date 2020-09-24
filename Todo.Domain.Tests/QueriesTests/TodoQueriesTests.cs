using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueriesTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "patriciamatta", DateTime.Now.AddDays(-1)));
            _items.Add(new TodoItem("Tarefa 4", "patriciamatta", DateTime.Now.AddDays(-1)));
            _items.Add(new TodoItem("Tarefa 5", "patriciamatta", DateTime.Now));
        }

        [TestMethod]
        public void Deve_retornar_tarefas_apenas_do_usuario_patriciamatta()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("patriciamatta"));

            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void Deve_retornar_tarefas_prontas_apenas_do_usuario_patriciamatta()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("patriciamatta"));

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Deve_retornar_tarefas_não_prontas_apenas_do_usuario_patriciamatta()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone("patriciamatta"));

            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void Deve_retornar_tarefas_do_periodo_apenas_do_usuario_patriciamatta()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("patriciamatta", DateTime.Now, false));

            Assert.AreEqual(1, result.Count());
        }
    }
}
