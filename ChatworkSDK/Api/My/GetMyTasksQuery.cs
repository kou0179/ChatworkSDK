using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<IEnumerable<MyTaskListResponse>> QueryAsync(GetMyTasksQuery query) => 
            QueryAsync<GetMyTasksQuery, IEnumerable<MyTaskListResponse>>(query);
    }

    internal class GetMyTasksQuery : GetQueryBase
    {
        public GetMyTasksQuery()
        {
        }

        public override string Path => "/my/tasks";
    }

    internal class MyTaskListResponse
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
