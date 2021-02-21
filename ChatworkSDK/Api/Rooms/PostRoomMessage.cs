#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<PostRoomMessageResponse> QueryAsync(PostRoomMessageQuery query) =>
            QueryAsync<PostRoomMessageQuery, PostRoomMessageResponse>(query);
    }

    internal class PostRoomMessageQuery : PostQueryBase
    {

        private string _body;
        private bool _selfUnread;
        private int _roomId;

        public PostRoomMessageQuery(int roomId, string body, bool selfUnread = false)
        {
            _roomId = roomId;
            _body = body;
            _selfUnread = selfUnread;
        }

        public override string Path => $"/rooms/{_roomId}/messages";

        public override IReadOnlyDictionary<string, string> BodyParameters => new Dictionary<string, string>() {
            { "body" , _body},
            { "self_unread", _selfUnread ? "1" : "0"}
        };
    }

    internal class PostRoomMessageResponse
    {
        public int message_id { get; set; }
    }
}
