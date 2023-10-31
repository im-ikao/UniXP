using System;
using System.Collections;
using UnityEngine;
using UniXP.Application.Model;
using UniXP.Domain;
using UniXP.Domain.Model;
using UniXP.Infrastructure;

namespace Plugins.CREEXTEAM.UniXP.Example
{
    public class Player : MonoBehaviour
    {
        public ExperiencedLevel ExperiencedLevel;
        
        private ExperiencedLevelDto FakeGetFromSaved()
        {
            return new ExperiencedLevelDto(24, 1);
        }

        private ILevelRecalculation FakeGetRecalculationFromConfiguration()
        {
            return new EvaluatedLevelRecalculation(new LinearLevelEvaluator(42));
        }

        public void Awake()
        {
            var dto = FakeGetFromSaved();
            var recalculation = FakeGetRecalculationFromConfiguration();
            ExperiencedLevel = dto.From(recalculation);
            
            ExperiencedLevel.XP.OnIncrease += (x) =>
            {
                Debug.Log("xp increased: " + x);
            };
            
            ExperiencedLevel.Level.OnIncrease += (x) =>
            {
                Debug.Log("Level increased: " + x);
            };

            StartCoroutine(TimedIncrease());
        }

        public IEnumerator TimedIncrease()
        {
            while (true)
            {
                ExperiencedLevel.XP.Increase(100);
                yield return new WaitForSeconds(1f);
            }
            
            yield break;
        }
    }
}