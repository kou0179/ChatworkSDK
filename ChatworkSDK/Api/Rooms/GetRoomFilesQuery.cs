#nullable enable

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<IEnumerable<RoomFileResponse>> QueryAsync(GetRoomFileQuery query) =>
            QueryAsync<GetRoomFileQuery, IEnumerable<RoomFileResponse>>(query);
    }

    internal class GetRoomFileQuery : GetQueryBase
    {
        private int _roomId;
        private int _fileId;
        private bool? createDownloadUrl;

        public GetRoomFileQuery(int roomId)
        {
            _roomId = roomId;
        }

        public override string Path => 
            $"/rooms/{_roomId}/files/{_fileId}{(createDownloadUrl.HasValue && createDownloadUrl.Value ? "?" + "create_download_url=1" : "")}";
    }

    internal class RoomFileResponse
    {
        public int file_id { get; set; }
        public Account account { get; set; }

        public string message_id { get; set; }
        public string filename { get; set; }
        public int filesize { get; set; }
        public int upload_time { get; set; }
        public string? download_url { get; set; }

        public class Account
        {
            public int account_id { get; set; }
            public string name { get; set; }
            public string avatar_image_url { get; set; }
        }
    }
}
