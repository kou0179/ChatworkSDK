using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<IEnumerable<RoomTaskListResponse>> QueryAsync(GetRoomTasksQuery query) =>
            QueryAsync<GetRoomTasksQuery, IEnumerable<RoomTaskListResponse>>(query);
    }

    internal class GetRoomTasksQuery : GetQueryBase
    {


        private int _roomId;
        private int? _accountId;
        private int? _assignedByAccountId;
        private TaskStatus? _status;

        public GetRoomTasksQuery(int roomId)
        {
            _roomId = roomId;
        }

        public override string Path { 
            get {
                var query = System.Web.HttpUtility.ParseQueryString("");

                if (_accountId.HasValue)
                    query.Add("account_id", _accountId.ToString());
                if (_assignedByAccountId.HasValue)
                    query.Add("assigned_by_account_id", _assignedByAccountId.ToString());
                if (_status.HasValue)
                    query.Add("status", _status.ToString().ToLower());

                var queryString = query.ToString();

                return $"/rooms/{_roomId}/tasks{(query.Count > 0 ? "?" + queryString : string.Empty )}";
           } 
        }
    }

    internal class RoomTaskListResponse
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
