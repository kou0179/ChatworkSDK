using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<RoomTaskResponse> QueryAsync(GetRoomTaskQuery query) =>
            QueryAsync<GetRoomTaskQuery, RoomTaskResponse>(query);
    }

    internal class GetRoomTaskQuery : GetQueryBase
    {
        private int _roomId;
        private int _taskId;

        public GetRoomTaskQuery(int roomId, int taskId)
        {
            _roomId = roomId;
            _taskId = taskId;
        }

        public override string Path => $"/rooms/{_roomId}/tasks/{_taskId}";
    }

    internal class RoomTaskResponse
    {
        public int task_id { get; set; }
        public Account account { get; set; }
        public Account assigned_by_account { get; set; }

        public string message_id { get; set; }
        public string body { get; set; }
        public int limit_time { get; set; }
        public TaskStatus status { get; set; }
        public TaskLimitType limit_type { get; set; }

        public class Account
        {
            public int account_id { get; set; }
            public string name { get; set; }
            public string avatar_image_url { get; set; }
        }
    }
}
