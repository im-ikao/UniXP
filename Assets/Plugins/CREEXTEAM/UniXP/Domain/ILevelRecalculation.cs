using UniXP.Domain.Model;

namespace UniXP.Domain
{
    public interface ILevelRecalculation
    {
        public void FromXP(ReactiveUnsignedInteger xp, ReactiveUnsignedInteger level);
        public void ToXP(ReactiveUnsignedInteger xp, ReactiveUnsignedInteger level);

    }
}