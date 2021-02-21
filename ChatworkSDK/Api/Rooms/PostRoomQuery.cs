#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<IEnumerable<RoomListResponse>> QueryAsync(PostRoomQuery query) =>
            QueryAsync<PostRoomQuery, IEnumerable<RoomListResponse>>(query);
    }

    internal class PostRoomQuery : PostQueryBase
    {

        private Request _request;

        public PostRoomQuery(Request request)
        {
            _request = request;
        }

        public override string Path => "/rooms";

        public override IReadOnlyDictionary<string, string> BodyParameters => QueryHandler.RequestObjectToStringDictionary(_request);

        public class Request
        {
            public Request(IEnumerable<int> members_admin_ids, string name)
            {
                if(members_admin_ids == null || !members_admin_ids.Any())
                {
                    throw new ArgumentException("members_admin_ids is require", nameof(members_admin_ids));
                }
                this.members_admin_ids = members_admin_ids;
                this.name = name;
            }

            public string? description { get; set; }
            public IconPreset? icon_preset { get; set; }
            public bool? link { get; set; }
            public string? link_code { get; set; }
            public bool? link_need_acceptance { get; set; }
            public IEnumerable<int> members_admin_ids { get; set; }
            public IEnumerable<int>? members_member_ids { get; set; }
            public IEnumerable<int>? members_readonly_ids { get; set; }
            public string name { get; set; }
        }

    }

    internal class PostRoomsResponse
    {
        public int room_id { get; set; }
    }
}
