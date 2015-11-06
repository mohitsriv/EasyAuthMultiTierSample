using System;
using System.Net.Http;
using Microsoft.Azure.AppService;

namespace MyDashDataAPI
{
    public static class MyDashDataAPIClientAppServiceExtensions
    {
        public static MyDashDataAPIClient CreateMyDashDataAPIClient(this IAppServiceClient client)
        {
            return new MyDashDataAPIClient(client.CreateHandler());
        }

        public static MyDashDataAPIClient CreateMyDashDataAPIClient(this IAppServiceClient client, params DelegatingHandler[] handlers)
        {
            return new MyDashDataAPIClient(client.CreateHandler(handlers));
        }

        public static MyDashDataAPIClient CreateMyDashDataAPIClient(this IAppServiceClient client, Uri uri, params DelegatingHandler[] handlers)
        {
            return new MyDashDataAPIClient(uri, client.CreateHandler(handlers));
        }

        public static MyDashDataAPIClient CreateMyDashDataAPIClient(this IAppServiceClient client, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
        {
            return new MyDashDataAPIClient(rootHandler, client.CreateHandler(handlers));
        }
    }
}
