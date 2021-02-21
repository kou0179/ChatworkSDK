using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<IEnumerable<AccountListResponse>> QueryAsync(GetContactsQuery query) =>
            QueryAsync<GetContactsQuery, IEnumerable<AccountListResponse>>(query);
    }

    internal class GetContactsQuery : GetQueryBase
    {
        public GetContactsQuery()
        {
        }

        public override string Path => "/contacts";
    }

    internal class AccountListResponse
    {
        public int account_id { get; set; }
        public int room_id { get; set; }
        public string name { get; set; }
        public string chatwork_id { get; set; }
        public int organization_id { get; set; }
        public string organization_name { get; set; }
        public string department { get; set; }
        public string avatar_image_url { get; set; }
    }
}
