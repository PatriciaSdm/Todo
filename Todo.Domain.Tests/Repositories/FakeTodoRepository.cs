using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public TodoItem GetById(Guid id, string user)
        {
            return new TodoItem("Titulo", "User", DateTime.Now);
        }
        public void Create(TodoItem todo)
        {
        }

        public void Update(TodoItem todo)
        {
        }
    }
}
