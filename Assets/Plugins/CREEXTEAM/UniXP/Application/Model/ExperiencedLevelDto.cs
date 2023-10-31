using System;
using UnityEngine;
using UniXP.Domain;
using UniXP.Domain.Model;

namespace UniXP.Application.Model
{
    [Serializable]
    public class ExperiencedLevelDto
    {
        public ExperiencedLevelDto(uint xp, uint level)
        {
            _xp = xp;
            _level = level;
        }

        [SerializeField] 
        private uint _xp = 0;
        public uint XP => _xp;

        [SerializeField] 
        private uint _level = 0;
        public uint Level => _level;

        public static ExperiencedLevelDto To(ExperiencedLevel model)
        {
            return new ExperiencedLevelDto(model.XP.Value, model.Level.Value);
        }

        public ExperiencedLevel From(ILevelRecalculation recalculation)
        {
            return new ExperiencedLevel(recalculation, new ReactiveUnsignedInteger(XP), new ReactiveUnsignedInteger(Level));
        }
    }
}