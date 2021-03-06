﻿using System.Collections.Generic;

namespace NadekoBot.Services.Database.Models
{
    public class XpSettings : DbEntity
    {
        public int GuildConfigId { get; set; }
        public GuildConfig GuildConfig { get; set; }

        public HashSet<XpRoleReward> RoleRewards { get; set; } = new HashSet<XpRoleReward>();
        public bool XpRoleRewardExclusive { get; set; }
        public string NotifyMessage { get; set; } = "Congratulations {0}! You have reached level {1}!";
        public HashSet<ExcludedItem> ExclusionList { get; set; } = new HashSet<ExcludedItem>();
        public bool ServerExcluded { get; set; }
    }

    public enum ExcludedItemType { Channel, Role }

    public class XpRoleReward : DbEntity
    {
        public int Level { get; set; }
        public ulong RoleId { get; set; }

        public override int GetHashCode()
        {
            return Level.GetHashCode() ^ RoleId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is XpRoleReward xrr && xrr.Level == Level && xrr.RoleId == RoleId;
        }
    }

    public class ExcludedItem : DbEntity
    {
        public ulong ItemId { get; set; }
        public ExcludedItemType ItemType { get; set; }

        public override int GetHashCode()
        {
            return ItemId.GetHashCode() ^ ItemType.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is ExcludedItem ei && ei.ItemId == ItemId && ei.ItemType == ItemType;
        }
    }
}
