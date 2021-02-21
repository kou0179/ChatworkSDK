#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<IEnumerable<DeleteRoomMessageResponse>> QueryAsync(DeleteRoomMessageQuery query) =>
            QueryAsync<DeleteRoomMessageQuery, IEnumerable<DeleteRoomMessageResponse>>(query);
    }

    internal class DeleteRoomMessageQuery : DeleteQueryBase
    {

        private int _roomId;
        private int _messageId;

        public DeleteRoomMessageQuery(int roomId, int messageId)
        {
            _roomId = roomId;
            _messageId = messageId;
        }

        public override string Path => $"/rooms/{_roomId}/messages/{_messageId}";
    }

    internal class DeleteRoomMessageResponse
    {
    }
}
