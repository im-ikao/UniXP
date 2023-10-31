using System;
using UniXP.Domain;

namespace UniXP.Infrastructure
{
    public class LinearLevelEvaluator : ILevelEvaluator
    {
        private readonly uint _minXP;
        
        public LinearLevelEvaluator(uint minXP)
        {
            _minXP = minXP;
        }
        
        public uint LevelToXP(uint level)
        {
            return (uint) ((Math.Pow(level, 2) + level) / 2 * _minXP - (level * _minXP));
        }
        
        public uint XPToLevel(uint xp)
        {
            return (uint) (Math.Sqrt(_minXP * ((2 * xp) + 25)) + 50) / 100;
        }
    }
}