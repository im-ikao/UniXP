using System;

namespace UniXP.Domain.Model
{
    public class ExperiencedLevel : Entity, IAggregateRoot
    {
        public ExperiencedLevel(
            ILevelRecalculation recalculation,
            ReactiveUnsignedInteger xp,
            ReactiveUnsignedInteger level)
        {
            Recalculation = recalculation;
            XP = xp;
            Level = level;
        }

        public ILevelRecalculation Recalculation { get; private set; }
        public ReactiveUnsignedInteger XP { get; private set; }
        public ReactiveUnsignedInteger Level { get; private set; }

        public void Recalculate() => Recalculation.FromXP(XP, Level);
    }
}