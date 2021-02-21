#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<IEnumerable<PutRoomMessageUnreadResponse>> QueryAsync(PutRoomMessageUnreadQuery query) =>
            QueryAsync<PutRoomMessageUnreadQuery, IEnumerable<PutRoomMessageUnreadResponse>>(query);
    }

    internal class PutRoomMessageUnreadQuery : PutQueryBase
    {

        private int _roomId;
        private string _messageId;

        public PutRoomMessageUnreadQuery(int roomId, string messageId)
        {
            _roomId = roomId;
            _messageId = messageId;
        }

        public override string Path => $"/rooms/{_roomId}/messages/read";

        public override IReadOnlyDictionary<string, string> BodyParameters => new Dictionary<string, string>() {
            { "message_id", _messageId}
        };
    }

    internal class PutRoomMessageUnreadResponse
    {
        public int unread_num { get; set; }
        public int mention_num { get; set; }
    }
}
