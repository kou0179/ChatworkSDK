#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<IEnumerable<RoomTaskListResponse>> QueryAsync(PostRoomTaskQuery query) =>
            QueryAsync<PostRoomTaskQuery, IEnumerable<RoomTaskListResponse>>(query);
    }

    internal class PostRoomTaskQuery : PostQueryBase
    {

        private Request _request;
        private int _roomId;

        public PostRoomTaskQuery(Request request)
        {
            _request = request;
        }

        public override string Path => $"/rooms/{_roomId}/tasks";

        public override IReadOnlyDictionary<string, string> BodyParameters => QueryHandler.RequestObjectToStringDictionary(_request);

        public class Request
        {
            public Request(string body, IEnumerable<int> to_ids)
            {
                this.body = body ?? throw new ArgumentNullException(nameof(body));
                if(to_ids == null || !to_ids.Any())
                {
                    throw new ArgumentException("require to_ids", nameof(to_ids));
                }
                this.to_ids = to_ids;
            }

            public string body { get; set; }
            public DateTime? limit { get; set; }
            public TaskLimitType? limit_type { get; set; }
            public IEnumerable<int> to_ids { get; set; }
        }

    }

    internal class PostRoomTasksResponse
    {
        public IEnumerable<int> task_ids { get; set; }
    }
}
