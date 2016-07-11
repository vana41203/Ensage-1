﻿namespace HpMpAbuse.Items
{
    using Ensage;

    using HpMpAbuse.Helpers;
    using HpMpAbuse.Menu;

    internal class SoulRing : UsableItem
    {
        #region Constructors and Destructors

        public SoulRing(string name)
            : base(name)
        {
        }

        #endregion

        #region Properties

        private static MenuManager Menu => Variables.Menu;

        #endregion

        #region Public Methods and Operators

        public override bool CanBeCasted()
        {
            return base.CanBeCasted() && Hero.Health / Hero.MaximumHealth * 100 >= Menu.SoulRing.HealthThreshold
                   && Hero.Mana / Hero.MaximumMana * 100 <= Menu.SoulRing.ManaThreshold
                   && ((Menu.Recovery.Active && Menu.Recovery.SoulRingEnabled)
                       || (!Menu.Recovery.Active && Menu.SoulRing.Enabled));
        }

        public override ItemsStats.Stats GetDropItemStats()
        {
            return Hero.Mana < Hero.MaximumMana ? ItemsStats.Stats.Mana : ItemsStats.Stats.None;
        }

        public override Attribute GetPowerTreadsAttribute()
        {
            return Attribute.Strength;
        }

        #endregion
    }
}