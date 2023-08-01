﻿using AtomicHomework.Enemy.Document;
using AtomicHomework.Entities.Components;
using Entities;
using UnityEngine;

namespace AtomicHomework.Atomic.Enemy.Entity
{
    public class EnemyEntity : MonoEntityBase
    {
        [SerializeField] private EnemyDocument _enemyDocument;
        
        private void Awake()
        {
            Add(new TakeBulletDamageComponent(_enemyDocument.EnemyLifeSection.OnTakeDamage));
            Add(new FollowComponent(_enemyDocument.FollowSection.OnFollow));
        }
    }
}