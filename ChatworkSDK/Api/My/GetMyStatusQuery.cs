using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<MyStatusResponse> QueryAsync(GetMyStatusQuery query) => QueryAsync<GetMyStatusQuery, MyStatusResponse>(query);
    }

    internal class GetMyStatusQuery : GetQueryBase
    {
        public GetMyStatusQuery()
        {
        }

        public override string Path => "/my/status";
    }

    internal class MyStatusResponse
    {
        public int unread_room_num { get; set; }
        public int mention_room_num { get; set; }
        public int mytask_room_num { get; set; }
        public int unread_num { get; set; }
        public int mention_num { get; set; }
        public int mytask_num { get; set; }
    }
}
