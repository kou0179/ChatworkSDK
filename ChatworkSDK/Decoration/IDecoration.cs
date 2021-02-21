using System;
using System.Collections.Generic;
using System.Text;

namespace ChatworkSDK.Decoration
{
    public interface IDecoration
    {
        public string ToChatworkFormat();
        public bool CanHasInner { get; }
    }
}
