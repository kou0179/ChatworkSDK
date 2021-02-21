using System;
using System.Collections.Generic;
using System.Text;

namespace ChatworkSDK.Decoration
{
    public class ToDecoration : IDecoration
    {
        public ToDecoration(int accountId)
        {
            AccountId = accountId;
        }

        public int AccountId { get; set; }

        public bool CanHasInner => false;

        public string ToChatworkFormat() => $"[To:{AccountId}]";
    }
}
