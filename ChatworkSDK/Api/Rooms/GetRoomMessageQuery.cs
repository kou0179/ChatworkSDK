using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<MessageResponse> QueryAsync(GetRoomMessageQuery query) =>
            QueryAsync<GetRoomMessageQuery, MessageResponse>(query);
    }

    internal class GetRoomMessageQuery : GetQueryBase
    {
        public GetRoomMessageQuery(int roomId, int messageId)
        {
            _roomId = roomId;
            _messageId = messageId;
        }

        private int _roomId;
        private int _messageId;

        public override string Path => $"/rooms/{_roomId}/messages/{_messageId}";
    }

    internal class MessageResponse
    {
        public string message_id { get; set; }
        public Account account { get; set; }
        public string body { get; set; }
        public int send_time { get; set; }
        public int update_time { get; set; }

        public class Account
        {
            public int account_id { get; set; }
            public string name { get; set; }
            public string avatar_image_url { get; set; }
        }
    }
}
