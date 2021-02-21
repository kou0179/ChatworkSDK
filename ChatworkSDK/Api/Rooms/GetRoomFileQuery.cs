using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<IEnumerable<RoomFileListResponse>> QueryAsync(GetRoomFilesQuery query) =>
            QueryAsync<GetRoomFilesQuery, IEnumerable<RoomFileListResponse>>(query);
    }

    internal class GetRoomFilesQuery : GetQueryBase
    {
        private int _roomId;
        private int? _accountId;

        public GetRoomFilesQuery(int roomId)
        {
            _roomId = roomId;
        }

        public override string Path => $"/rooms/{_roomId}/files{(_accountId.HasValue ? "?" + "account_id=" + _accountId : string.Empty)}";
    }

    internal class RoomFileListResponse
    {
        public int file_id { get; set; }
        public Account account { get; set; }

        public string message_id { get; set; }
        public string filename { get; set; }
        public int filesize { get; set; }
        public int upload_time { get; set; }

        public class Account
        {
            public int account_id { get; set; }
            public string name { get; set; }
            public string avatar_image_url { get; set; }
        }
    }
}
