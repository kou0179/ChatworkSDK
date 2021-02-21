using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ChatworkSDK.Api
{
    interface IQuery
    {
        string Path { get; }
        IReadOnlyDictionary<string,string> BodyParameters { get; }
        HttpMethod Method { get; }
    }

    internal abstract class GetQueryBase : IQuery
    {
        public abstract string Path { get; }
        public IReadOnlyDictionary<string,string> BodyParameters { get; } = null;
        public HttpMethod Method { get; } = HttpMethod.Get;

    }
    internal abstract class PostQueryBase : IQuery
    {
        public abstract string Path { get; }
        public abstract IReadOnlyDictionary<string, string> BodyParameters { get; }
        public HttpMethod Method { get; } = HttpMethod.Post;

    }
    internal abstract class PutQueryBase : IQuery
    {
        public abstract string Path { get; }
        public abstract IReadOnlyDictionary<string, string> BodyParameters { get; }
        public HttpMethod Method { get; } = HttpMethod.Put;
    }
    internal abstract class DeleteQueryBase : IQuery
    {
        public abstract string Path { get; }
        public IReadOnlyDictionary<string, string> BodyParameters { get; } = null;
        public HttpMethod Method { get; } = HttpMethod.Delete;

    }
}
