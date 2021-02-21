using System;
using System.Collections.Generic;
using System.Text;

namespace ChatworkSDK.Decoration
{
    public class ReplyDecoration : IDecoration
    {
        public ReplyDecoration(int accountId, int roomId, int messageId)
        {
            AccountId = accountId;
            RoomId = roomId;
            MessageId = messageId;
        }

        public int AccountId { get; set; }
        public int RoomId { get; set; }
        public int MessageId { get; set; }
        public bool CanHasInner => false;

        public string ToChatworkFormat() => $"[rp aid={AccountId} to={RoomId}-{MessageId}]";
    }
}
