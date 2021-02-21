using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatworkSDK.Api
{
    internal partial class QueryHandler
    {
        public Task<DeleteRoomResponse> QueryAsync(DeleteRoomQuery query) =>
            QueryAsync<DeleteRoomQuery, DeleteRoomResponse>(query);
    }

    // Deleteであるが，ReqBodyを要求されているため，
    // PostでURLクエリストリングにmethod=DELETEを付与してDELETE動作をさせる。
    internal class DeleteRoomQuery : PostQueryBase
    {
        public DeleteRoomQuery(int roomId, ActionType actionType)
        {
            _roomId = roomId;
            _actionType = actionType;
        }

        private int _roomId;
        private ActionType _actionType;

        public override string Path => $"/rooms/{_roomId}?method=DELETE";

        public override IReadOnlyDictionary<string, string> BodyParameters => 
            new Dictionary<string, string>() { { "action_type", _actionType.ToString().ToLower() } };

        public enum ActionType
        {
            Leave,
            Delete
        }
    }

    internal class DeleteRoomResponse
    {

    }
}
