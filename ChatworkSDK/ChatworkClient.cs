using System;
using ChatworkSDK.Api;

namespace ChatworkSDK {
    public interface IChatworkClient
    {
        
    }
    public class ChatworkClient {
        private QueryHandler _queryHandler;

        public ChatworkClient(string token)
        {
            _queryHandler = new QueryHandler(token);
        }
    }
}
