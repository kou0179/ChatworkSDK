#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<PutRoomMembersResponse> QueryAsync(PutRoomMembersQuery query) =>
            QueryAsync<PutRoomMembersQuery, PutRoomMembersResponse>(query);
    }

    internal class PutRoomMembersQuery : PutQueryBase
    {
        public PutRoomMembersQuery(int roomId, Request request)
        {
            _roomId = roomId;
            _request = request;
        }

        private Request _request;

        private int _roomId;

        public override string Path => $"/rooms/{_roomId}/members";

        public override IReadOnlyDictionary<string, string> BodyParameters => QueryHandler.RequestObjectToStringDictionary(_request);

        public class Request
        {
            public Request(IEnumerable<int> members_admin_ids)
            {
                if (members_admin_ids == null || !members_admin_ids.Any())
                {
                    throw new ArgumentException("members_admin_ids is require", nameof(members_admin_ids));
                }
                this.members_admin_ids = members_admin_ids;
            }

            public IEnumerable<int> members_admin_ids { get; set; }
            public IEnumerable<int>? members_member_ids { get; set; }
            public IEnumerable<int>? members_readonly_ids { get; set; }
        }

    }

    internal class PutRoomMembersResponse
    {
        public IEnumerable<int> admin { get; set; }
        public IEnumerable<int> member { get; set; }
        [JsonPropertyName("readonly")]
        public IEnumerable<int> readonly_ { get; set; }
    }
}
