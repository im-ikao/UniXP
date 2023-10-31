using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UniXP.Application.Model;
using UniXP.Domain;
using UniXP.Infrastructure;

namespace Plugins.CREEXTEAM.UniXP.Application
{
    [Serializable]
    [CreateAssetMenu]
    public class LinearCalculationPredictor : ScriptableObject
    {
        [SerializeField] private List<ExperiencedLevelDto> _levels = new List<ExperiencedLevelDto>();
        [SerializeField] private uint _minXp = 0;
        [SerializeField] private uint _predictCount = 0;

        public void OnValidate()
        {
            ILevelEvaluator evaluator = new LinearLevelEvaluator(_minXp);
            
            _levels.Clear();
            for (uint i = 1; i < _predictCount; i++)
            {
                _levels.Add(new ExperiencedLevelDto(i, evaluator.LevelToXP(i)));
            }
        }
    }
}