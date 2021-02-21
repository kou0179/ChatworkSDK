#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatworkSDK.Decoration
{
    public class InformationDecoration : IDecoration
    {
        public InformationDecoration(string inner)
        {
            Inner = inner;
        }

        public bool CanHasInner => true;
        public string Inner { get; set; }

        public string ToChatworkFormat() => $"[info]{Inner}[/info]";
    }
}
