using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<IEnumerable<MessageListResponse>> QueryAsync(GetRoomMessagesQuery query) =>
            QueryAsync<GetRoomMessagesQuery, IEnumerable<MessageListResponse>>(query);
    }

    /// <summary>
    /// チャットのメッセージ一覧を取得。パラメータ未指定だと前回取得分からの差分のみを返します。(最大100件まで取得)
    /// </summary>
    internal class GetRoomMessagesQuery : GetQueryBase
    {
        public GetRoomMessagesQuery(int roomId)
        {
            _roomId = roomId;
        }

        private int _roomId;

        public override string Path => $"/rooms/{_roomId}/messages";
    }

    internal class MessageListResponse
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
