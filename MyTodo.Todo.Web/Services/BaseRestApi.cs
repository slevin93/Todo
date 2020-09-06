using Flurl.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using System.Threading.Tasks;

namespace MyTodo.Todo.Web.Services
{
    public class BaseRestApi
    {
        public virtual Task<T> GetJsonAsync<T>(string url)
        {
            try
            {
                return url.GetJsonAsync<T>();
            }
            catch { }

            return default;
        }

        public virtual async Task DeleteAsync(string url, int id)
        {
            try
            {
                await url.SendJsonAsync(System.Net.Http.HttpMethod.Delete, new { Id = id });
            }
            catch { }
        }

        public virtual async Task PostAsync(string url, object data)
        {
            try
            {
                await url.SendJsonAsync(System.Net.Http.HttpMethod.Post, data);
            }
            catch { }
        }

        public virtual async Task PutAsync(string url, object data)
        {
            try
            {
                await url.PutJsonAsync(data);
            }
            catch { }
        }
    }
}
