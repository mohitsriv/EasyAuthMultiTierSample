﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using MyDashDataAPI;
using MyDashDataAPI.Models;

namespace MyDashDataAPI
{
    public static partial class TodoListExtensions
    {
        /// <param name='operations'>
        /// Reference to the MyDashDataAPI.ITodoList.
        /// </param>
        /// <param name='owner'>
        /// Required.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        public static object Delete(this ITodoList operations, string owner, int id)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ITodoList)s).DeleteAsync(owner, id);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the MyDashDataAPI.ITodoList.
        /// </param>
        /// <param name='owner'>
        /// Required.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<object> DeleteAsync(this ITodoList operations, string owner, int id, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<object> result = await operations.DeleteWithOperationResponseAsync(owner, id, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the MyDashDataAPI.ITodoList.
        /// </param>
        /// <param name='owner'>
        /// Required.
        /// </param>
        public static IList<Todo> Get(this ITodoList operations, string owner)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ITodoList)s).GetAsync(owner);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the MyDashDataAPI.ITodoList.
        /// </param>
        /// <param name='owner'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<IList<Todo>> GetAsync(this ITodoList operations, string owner, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<MyDashDataAPI.Models.Todo>> result = await operations.GetWithOperationResponseAsync(owner, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the MyDashDataAPI.ITodoList.
        /// </param>
        /// <param name='owner'>
        /// Required.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        public static Todo GetById(this ITodoList operations, string owner, int id)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ITodoList)s).GetByIdAsync(owner, id);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the MyDashDataAPI.ITodoList.
        /// </param>
        /// <param name='owner'>
        /// Required.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<Todo> GetByIdAsync(this ITodoList operations, string owner, int id, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<MyDashDataAPI.Models.Todo> result = await operations.GetByIdWithOperationResponseAsync(owner, id, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the MyDashDataAPI.ITodoList.
        /// </param>
        /// <param name='todo'>
        /// Required.
        /// </param>
        public static object Post(this ITodoList operations, Todo todo)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ITodoList)s).PostAsync(todo);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the MyDashDataAPI.ITodoList.
        /// </param>
        /// <param name='todo'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<object> PostAsync(this ITodoList operations, Todo todo, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<object> result = await operations.PostWithOperationResponseAsync(todo, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the MyDashDataAPI.ITodoList.
        /// </param>
        /// <param name='todo'>
        /// Required.
        /// </param>
        public static object Put(this ITodoList operations, Todo todo)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ITodoList)s).PutAsync(todo);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the MyDashDataAPI.ITodoList.
        /// </param>
        /// <param name='todo'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<object> PutAsync(this ITodoList operations, Todo todo, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<object> result = await operations.PutWithOperationResponseAsync(todo, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}