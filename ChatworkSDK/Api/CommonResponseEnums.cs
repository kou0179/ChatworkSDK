using System;
using System.Collections.Generic;
using System.Text;

namespace ChatworkSDK.Api
{
    internal enum IconPreset
    {
        Group, Check, Document, Meeting, Event, Project, Business, Study, Security, Star, Idea, Heart, Magcup, Beer, Music, Sports, Travel
    }

    internal enum RoomType
    {
        My,
        Direct,
        Group
    }

    internal enum RoomMemberRole
    {
        Admin,
        Member,
        Readonly
    }

    public enum TaskStatus
    {
        Open,
        Done,
    }

    public enum TaskLimitType
    {
        None,
        Date,
        Time,
    }

}
