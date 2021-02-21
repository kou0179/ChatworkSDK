using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ChatworkSDK.test")]
namespace ChatworkSDK.Api
{
    /// <summary>
    /// 認証とベースURLの抽象化
    /// </summary>
    internal partial class QueryHandler
    {
        private AuthKind _authKind = AuthKind.Token;
        private HttpClient _client;
        public QueryHandler(string token)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.chatwork.com/v2/");
            _client.DefaultRequestHeaders.Add("X-ChatWorkToken", token);
        }

        public async Task<TResult> QueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            if (query.Method == HttpMethod.Get)
            {
                var response = await _client.GetAsync(query.Path).ConfigureAwait(false);
                var resultTask = ReadFromJsonAsync<TResult>(response);
                return await resultTask.ConfigureAwait(false);
            }
            if (query.Method == HttpMethod.Post)
            {
                var content = new FormUrlEncodedContent(query.BodyParameters);
                var response = await _client.PostAsync(query.Path, content).ConfigureAwait(false);
                var resultTask = ReadFromJsonAsync<TResult>(response);
                return await resultTask.ConfigureAwait(false);
            }
            if (query.Method == HttpMethod.Delete)
            {
                var response = await _client.DeleteAsync(query.Path).ConfigureAwait(false);
                var resultTask = ReadFromJsonAsync<TResult>(response);
                return await resultTask.ConfigureAwait(false);
            }
            if (query.Method == HttpMethod.Put)
            {
                var content = new FormUrlEncodedContent(query.BodyParameters);
                var response = await _client.PostAsync(query.Path, content).ConfigureAwait(false);
                var resultTask = ReadFromJsonAsync<TResult>(response);
                return await resultTask.ConfigureAwait(false);
            }

            throw new ArgumentException("Not supoorted method", nameof(query));
        }

        private static async Task<TBody> ReadFromJsonAsync<TBody>(HttpResponseMessage response)
        {
            if (response.Content == null) return default(TBody);

            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<TBody>(content);
        }

        // TODO: リファクタ
        public static IReadOnlyDictionary<string, string> RequestObjectToStringDictionary(object obj)
        {
            return obj.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(prop => prop.GetValue(obj, null) != null)
                .ToDictionary(prop => prop.Name, prop => {
                    bool isGenericIEnumerable = prop.PropertyType.IsGenericType && prop.PropertyType
                                    .GetInterfaces()
                                    .Any(t => t == typeof(IEnumerable));
                    // IEnumerable<string>, IEnumerable<int> はカンマ区切りで文字列化
                    if (prop.PropertyType != typeof(string) && isGenericIEnumerable)
                    {
                        if(prop.PropertyType.GenericTypeArguments[0] == typeof(string))
                        {
                            return string.Join(',', (IEnumerable<string>)prop.GetValue(obj, null));
                        }
                        else if(prop.PropertyType.GenericTypeArguments[0] == typeof(int))
                        {
                            return string.Join(',', (IEnumerable<int>)prop.GetValue(obj, null));
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    // enum は全小文字で文字列化
                    else if (prop.PropertyType.IsEnum)
                    {
                        return prop.GetValue(obj, null).ToString().ToLower();
                    }
                    // bool は false = 0 / true = 1 で文字列化
                    else if (prop.PropertyType == typeof(bool))
                    {
                        return (bool)prop.GetValue(obj, null) ? "1" : "0";
                    }
                    // DateTimeはunixタイムに変換
                    else if (prop.PropertyType == typeof(DateTime))
                    {
                        return ((int)((DateTime)prop.GetValue(obj, null)).Subtract(new DateTime(1970,1,1)).TotalSeconds).ToString();
                    }
                    else
                    {
                        return prop.GetValue(obj, null).ToString();
                    }
                });
        }
    }

    internal enum AuthKind : byte
    {
        Token,
        // TODO: OAuth
    }
}
