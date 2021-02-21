using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<IEnumerable<RoomMemberListResponse>> QueryAsync(GetRoomMembersQuery query) =>
            QueryAsync<GetRoomMembersQuery, IEnumerable<RoomMemberListResponse>>(query);
    }

    internal class GetRoomMembersQuery : GetQueryBase
    {
        public GetRoomMembersQuery(int roomId)
        {
            _roomId = roomId;
        }

        private int _roomId;

        public override string Path => $"/rooms/{_roomId}/members";
    }

    internal class RoomMemberListResponse
    {
        public int account_id { get; set; }
        public RoomMemberRole role { get; set; }
        public string name { get; set; }
        public string chatwork_id { get; set; }
        public int organization_id { get; set; }
        public string organization_name { get; set; }
        public string department { get; set; }
        public string avatar_image_url { get; set; }
    }
}
