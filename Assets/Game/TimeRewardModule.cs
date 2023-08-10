﻿using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game
{
    public class TimeRewardModule : MonoBehaviour, IInitializable
    {
        [ShowInInspector] private TimeReward _timeReward = new();
        [SerializeField] private TimeRewardConfig _timeRewardConfig;
        [SerializeField] private TimeRewardReceiver _timeRewardReceiver;
        [SerializeField] private TimeRewardSaveLoader _saveLoader;
        
        public void Initialize()
        {
            _timeReward.Construct(_timeRewardConfig);
            _timeRewardReceiver.Construct(_timeRewardConfig, _timeReward);
            _saveLoader.Construct(_timeReward);
        }

        private void Start()
        {
            _timeReward.Start();
        }
    }
}