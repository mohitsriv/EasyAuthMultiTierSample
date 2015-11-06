using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;
using MyDashDataAPI;
using System.Threading.Tasks;
using MyDashAPI.Filters;
using System.Net.Http.Headers;
using System.Configuration;

namespace MyDashAPI.Filters
{
    using System.Web.Http.Filters;

    public class HttpOperationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is Microsoft.Rest.HttpOperationException)
            {
                var ex = (Microsoft.Rest.HttpOperationException)context.Exception;
                context.Response = ex.Response;
            }
        }
    }
}

namespace MyDashAPI.Controllers
{   
    [HttpOperationExceptionFilterAttribute]
    public class TodoListController : ApiController
    {
        private static MyDashDataAPIClient NewDataAPIClient()
        {
            var client = new MyDashDataAPIClient(new Uri(ConfigurationManager.AppSettings["DataAPIUrl"]));
            client.HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", ServicePrincipal.GetS2SAccessTokenForProdMSA().AccessToken);
            return client;
        }

        // GET: api/TodoList
        public async Task<IEnumerable<Todo>> GetAsync()
        {
            string owner = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value;
            using (var client = NewDataAPIClient())
            {
                var results = await client.TodoList.GetAsync(owner);
                return results.Select(m => new Todo
                {
                    Description = m.Description,
                    ID = (int)m.ID,
                    Owner = m.Owner
                });
            }
        }

        // GET: api/TodoList/5
        public async Task<Todo> GetAsync(int id)
        {
            string owner = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value;
            using (var client = NewDataAPIClient())
            {
                var result = await client.TodoList.GetByIdAsync(owner, id);
                return new Todo
                {
                    Description = result.Description,
                    ID = (int)result.ID,
                    Owner = result.Owner
                };
            }
        }

        // POST: api/TodoList
        public async Task Post(Todo todo)
        {
            string owner = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value;
            todo.Owner = owner;
            using (var client = NewDataAPIClient())
            {
                await client.TodoList.PostAsync(new MyDashDataAPI.Models.Todo
                {
                    Description = todo.Description,
                    ID = todo.ID,
                    Owner = todo.Owner
                });
            }
        }

        public async Task Put(Todo todo)
        {
            string owner = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value;
            todo.Owner = owner;
            using (var client = NewDataAPIClient())
            {
                await client.TodoList.PutAsync(new MyDashDataAPI.Models.Todo
                {
                    Description = todo.Description,
                    ID = todo.ID,
                    Owner = todo.Owner
                });
            }
        }

        // DELETE: api/TodoList/5
        public async Task Delete(int id)
        {
            string owner = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value;
            using (var client = NewDataAPIClient())
            {
                await client.TodoList.DeleteAsync(owner, id);
            }
        }
    }
}
