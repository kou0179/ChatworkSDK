using System;
using System.Collections.Generic;
using System.Text;
using ChatworkSDK.Extensions;

namespace ChatworkSDK.Decoration
{
    public class QuoteDecoration : IDecoration
    {
        public QuoteDecoration(int accountId, string inner, DateTime? timeStamp = null)
        {
            AccountId = accountId;
            Inner = inner;
            TimeStamp = timeStamp;
        }

        public bool CanHasInner => true;
        public int AccountId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string Inner { get; set; }
        public string ToChatworkFormat() => TimeStamp.HasValue ? $"[qt][qtmeta aid={AccountId} time={TimeStamp.Value.ToUnixTimestamp()}]{Inner}[/qt]"
            : $"[qt][qtmeta aid={AccountId}]{Inner}[/qt]";
    }
}
