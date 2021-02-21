#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<IEnumerable<PutRoomMessageReadResponse>> QueryAsync(PutRoomMessageReadQuery query) =>
            QueryAsync<PutRoomMessageReadQuery, IEnumerable<PutRoomMessageReadResponse>>(query);
    }

    internal class PutRoomMessageReadQuery : PutQueryBase
    {

        private int _roomId;
        private string _messageId;

        public PutRoomMessageReadQuery(int roomId, string messageId)
        {
            _roomId = roomId;
            _messageId = messageId;
        }

        public override string Path => $"/rooms/{_roomId}/messages";

        public override IReadOnlyDictionary<string, string> BodyParameters => new Dictionary<string, string>() {
            { "message_id", _messageId}
        };
    }

    internal class PutRoomMessageReadResponse
    {
        public int unread_num { get; set; }
        public int mention_num { get; set; }
    }
}
