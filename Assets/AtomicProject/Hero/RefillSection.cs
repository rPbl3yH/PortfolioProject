﻿using System;
using Atomic;
using AtomicHomework.Atomic.Custom;
using Declarative;

namespace AtomicHomework.Hero
{
    [Serializable]
    public class RefillSection
    {
        public Timer _bulletRefillTimer = new();
        public AtomicVariable<int> BulletRefillDelay;
        public AtomicVariable<int> MaxCount;
        
        [Construct]
        public void Construct(FireSection fireSection)
        {
            _bulletRefillTimer.Construct(BulletRefillDelay.Value);
            _bulletRefillTimer.StartTimer();
            
            fireSection.OnFire += () =>
            {
                _bulletRefillTimer.StartTimer();
            };
            
            _bulletRefillTimer.OnTimerFinished += () =>
            {
                fireSection.BulletCount.Value++;

                if (fireSection.BulletCount.Value < MaxCount.Value)
                {
                    _bulletRefillTimer.StartTimer();
                }
            };
        }
    }
}