using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<PutRoomTaskStatusResponse> QueryAsync(PutRoomTaskStatusQuery query) =>
            QueryAsync<PutRoomTaskStatusQuery, PutRoomTaskStatusResponse>(query);
    }

    internal class PutRoomTaskStatusQuery : PutQueryBase
    {
        private int _roomId;
        private int _taskId;
        private TaskStatus _taskStatus;

        public PutRoomTaskStatusQuery(int roomId, int taskId, TaskStatus taskStatus)
        {
            _roomId = roomId;
            _taskId = taskId;
            _taskStatus = taskStatus;
        }

        public override string Path => $"/rooms/{_roomId}/tasks/{_taskId}";

        public override IReadOnlyDictionary<string, string> BodyParameters =>
            new Dictionary<string, string>() { { "body", _taskStatus.ToString().ToLower() } };
    }

    internal class PutRoomTaskStatusResponse
    {
        public int task_id { get; set; }
    }
}
