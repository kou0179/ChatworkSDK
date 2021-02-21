#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<IEnumerable<RoomListResponse>> QueryAsync(PutRoomQuery query) =>
            QueryAsync<PutRoomQuery, IEnumerable<RoomListResponse>>(query);
    }

    internal class PutRoomQuery : PutQueryBase
    {

        private Request _request;

        public PutRoomQuery(int roomId)
        {
            _roomId = roomId;
        }

        private int _roomId;

        public override string Path => $"/rooms/{_roomId}";

        public override IReadOnlyDictionary<string, string> BodyParameters => QueryHandler.RequestObjectToStringDictionary(_request);

        public class Request
        {
            public Request()
            {
            }

            public string? description { get; set; }
            public IconPreset? icon_preset { get; set; }
            public string? name { get; set; }
        }

    }

    internal class PutRoomsResponse
    {
        public int room_id { get; set; }
    }
}
