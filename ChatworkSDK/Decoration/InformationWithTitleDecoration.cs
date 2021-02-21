#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatworkSDK.Decoration
{
    public class InformationWithTitleDecoration : IDecoration
    {
        public InformationWithTitleDecoration(string title, string inner)
        {
            Title = title;
            Inner = inner;
        }

        public bool CanHasInner => true;
        public string Title { get; set; }
        public string Inner { get; set; }

        public string ToChatworkFormat() => $"[info][title]{Title}[/title]{Inner}[/info]";
    }
}
