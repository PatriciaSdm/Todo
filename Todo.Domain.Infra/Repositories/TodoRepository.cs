using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;

        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            //AsNoTracking = usar quando não vai fazer um update ou delete no objeto, elimina um passo e deixa mais rapido
            return _context.Todos
                           .AsNoTracking()
                           .Where(TodoQueries.GetAll(user))
                           .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return _context.Todos.AsNoTracking()
                                .Where(TodoQueries.GetAllDone(user))
                                .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            return _context.Todos.AsNoTracking()
                                 .Where(TodoQueries.GetAllUndone(user))
                                 .OrderBy(x => x.Date);
        }

        public TodoItem GetById(Guid id, string user)
        {
            return _context.Todos
                           .FirstOrDefault(x => x.Id == id && x.User == user);
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            return _context.Todos.AsNoTracking()
                              .Where(TodoQueries.GetByPeriod(user, date, done))
                              .OrderBy(x => x.Date);
        }

        public void Create(TodoItem todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public void Update(TodoItem todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
