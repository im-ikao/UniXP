using UniXP.Domain.Model;

namespace UniXP.Domain
{
    public interface ILevelEvaluator
    {
        public uint LevelToXP(uint level);
        public uint XPToLevel(uint xp);
    }
}