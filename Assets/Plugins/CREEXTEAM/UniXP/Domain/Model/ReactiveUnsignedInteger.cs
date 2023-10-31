using System;
using UnityEngine;

namespace UniXP.Domain.Model
{
    public delegate void OnChanged(uint value);
    public sealed class ReactiveUnsignedInteger : Entity<Guid>
    {
        public OnChanged OnChanged;
        public OnChanged OnIncrease;
        public OnChanged OnDecrease;
        
        private uint _value;
        public uint Value
        {
            get => _value;
            private set
            {
                var lastValue = _value;
                _value = value;

                if (lastValue > value)
                    OnDecrease?.Invoke(value);
                else if (lastValue < value)
                    OnIncrease?.Invoke(value);
            
                if (lastValue != value)
                    OnChanged?.Invoke(value);
            }
        }

        public ReactiveUnsignedInteger(Guid key, uint value)
        {
            Id = key;
            _value = value;
        }
        
        
        public ReactiveUnsignedInteger(uint value) : this(Guid.NewGuid(), value)
        {
            
        }

        public void Increase(uint value)
        {
            Value = _value + value;
        }

        public void Decrease(uint value)
        {
            if (CanDecrease(value) == false)
                throw new ArithmeticException();
            
            Value = _value - value;
        }

        public void Set(uint value)
        {
            Value = value;
        }
        
        public bool CanDecrease(uint value)
        {
            return _value >= value;
        }
    }
}