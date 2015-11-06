using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;
using System.IdentityModel.Tokens;
using System.Diagnostics;

namespace MyDashDataAPI.Controllers
{   
    public class TodoListController : ApiController
    {
        private static Dictionary<int, Todo> mockData = new Dictionary<int, Todo>();

        static TodoListController()
        {
            mockData.Add(0, new Todo { ID = 0, Owner = "Mohit", Description = "Fix the umbrella" });
            mockData.Add(1, new Todo { ID = 0, Owner = "Shalaka", Description = "Put Daivan to sleep" });
        }

        // GET: api/TodoList
        public IEnumerable<Todo> Get(string owner)
        {
            return mockData.Values.Where(m => m.Owner == owner);
        }

        // GET: api/TodoList/5
        public Todo GetById(string owner, int id)
        {
            return mockData.Values.Where(m => m.Owner == owner && m.ID == id).First();
        }

        // POST: api/TodoList
        public void Post(Todo todo)
        {
            todo.ID = mockData.Keys.Max() + 1;
            mockData.Add(todo.ID, todo);
        }

        public void Put(Todo todo)
        {
            Todo xtodo = mockData.Values.First(a => a.Owner == todo.Owner && a.ID == todo.ID);
            if (todo != null && xtodo != null)
            {
                xtodo.Description = todo.Description;
            }
        }

        // DELETE: api/TodoList/5
        public void Delete(string owner, int id)
        {
            Todo todo = mockData.Values.First(a => a.Owner == owner && a.ID == id);
            if (todo != null)
            {
                mockData.Remove(todo.ID);
            }
        }        
    }
}
