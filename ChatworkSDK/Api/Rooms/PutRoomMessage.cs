#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<PutRoomMessageResponse> QueryAsync(PutRoomMessageQuery query) =>
            QueryAsync<PutRoomMessageQuery, PutRoomMessageResponse>(query);
    }

    internal class PutRoomMessageQuery : PutQueryBase
    {

        private int _roomId;
        private int _messageId;
        private string _body;

        public PutRoomMessageQuery(int roomId, int messageId, string body)
        {
            _roomId = roomId;
            _messageId = messageId;
            _body = body;
        }

        public override string Path => $"/rooms/{_roomId}/messages/{_messageId}";

        public override IReadOnlyDictionary<string, string> BodyParameters => new Dictionary<string, string>() {
            { "body" , _body}
        };
    }

    internal class PutRoomMessageResponse
    {
        public int message_id { get; set; }
    }
}
