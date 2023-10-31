using System;

namespace UniXP.Domain.Model
{
    public class ExperiencedLevel : Entity<Guid>, IAggregateRoot
    {
        public ExperiencedLevel(
            ILevelRecalculation recalculation,
            ReactiveUnsignedInteger xp,
            ReactiveUnsignedInteger level)
        {
            Id = Guid.NewGuid();
            Recalculation = recalculation;
            XP = xp;
            Level = level;
            
            OnEnable();
        }

        public ILevelRecalculation Recalculation { get; private set; }
        public ReactiveUnsignedInteger XP { get; private set; }
        public ReactiveUnsignedInteger Level { get; private set; }

        public void OnEnable()
        {
            XP.OnChanged += OnXPChanged;
        }

        public void OnDisable()
        {
            XP.OnChanged -= OnXPChanged;
        }
        
        public void Recalculate() => Recalculation.FromXP(XP, Level);
        private void OnXPChanged(uint xp) => Recalculate();
    }
}