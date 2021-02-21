using System;
using System.Collections.Generic;
using System.Text;

namespace ChatworkSDK.Decoration
{
    public class CodeDecoration : IDecoration
    {
        public CodeDecoration(string inner)
        {
            Inner = inner;
        }

        public bool CanHasInner => true;
        public string Inner { get; set; }

        public string ToChatworkFormat() => $"[code]{Inner}[/code]";
    }
}
