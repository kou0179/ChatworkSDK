using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<RoomResponse> QueryAsync(GetRoomQuery query) =>
            QueryAsync<GetRoomQuery, RoomResponse>(query);
    }

    internal class GetRoomQuery : GetQueryBase
    {
        public GetRoomQuery(int roomId)
        {
            _roomId = roomId;
        }

        private int _roomId;

        public override string Path => $"/rooms/{_roomId}";
    }

    internal class RoomResponse
    {
        public int room_id { get; set; }
        public string name { get; set; }
        public RoomType type { get; set; }
        public RoomMemberRole role { get; set; }
        public bool sticky { get; set; }
        public int unread_num { get; set; }
        public int mention_num { get; set; }
        public int mytask_num { get; set; }
        public int message_num { get; set; }
        public int file_num { get; set; }
        public int task_num { get; set; }
        public string icon_path { get; set; }
        public int last_update_time { get; set; }
        public string description { get; set; }
    }
}
