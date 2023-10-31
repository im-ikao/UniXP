using System;
using UniXP.Domain;
using UniXP.Domain.Model;

namespace UniXP.Infrastructure
{
    public class EvaluatedLevelRecalculation : ILevelRecalculation
    {
        private ILevelEvaluator _evaluator;
        public EvaluatedLevelRecalculation(ILevelEvaluator evaluator)
        {
            _evaluator = evaluator;
        }
        
        public void FromXP(ReactiveUnsignedInteger xp, ReactiveUnsignedInteger level)
        {
            if (xp == null)
                throw new NullReferenceException();
            
            if (level == null)
                throw new NullReferenceException();
            
            var calcLevel = _evaluator.XPToLevel(xp.Value);
            level.Set(calcLevel);
        }

        public void ToXP(ReactiveUnsignedInteger xp, ReactiveUnsignedInteger level)
        {
            if (xp == null)
                throw new NullReferenceException();
            
            if (level == null)
                throw new NullReferenceException();
            
            var calcXP = _evaluator.XPToLevel(xp.Value);
            xp.Set(calcXP);
        }

        public uint GetNextLevelXP(ReactiveUnsignedInteger level)
        {
            return _evaluator.LevelToXP(level.Value + 1);
        }

        public uint GetCurrentLevelXP(ReactiveUnsignedInteger level)
        {
            return _evaluator.LevelToXP(level.Value);
        }
    }
}