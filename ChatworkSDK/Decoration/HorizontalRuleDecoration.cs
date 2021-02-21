using System;
using System.Collections.Generic;
using System.Text;

namespace ChatworkSDK.Decoration
{
    public class HorizontalRuleDecoration : IDecoration
    {
        public HorizontalRuleDecoration()
        {
        }

        public bool CanHasInner => false;

        public string ToChatworkFormat() => "[hr]";
    }
}
