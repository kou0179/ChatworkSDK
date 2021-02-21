using System;
using System.Collections.Generic;
using System.Text;

namespace ChatworkSDK.Decoration
{
    public class AccountIconWithNameDecoration : IDecoration
    {
        public AccountIconWithNameDecoration(int accountId)
        {
            AccountId = accountId;
        }

        public bool CanHasInner => false;
        public int AccountId { get; set; }
        public string ToChatworkFormat() => $"[piconname:{AccountId}]";
    }
}
