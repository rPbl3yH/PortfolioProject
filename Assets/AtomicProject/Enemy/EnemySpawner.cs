﻿using System;
using System.Collections;
using AtomicHomework.Atomic.Enemy.Entity;
using AtomicHomework.Entities.Components;
using AtomicHomework.Hero;
using ModestTree.Util;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AtomicHomework.Atomic.Enemy.Document
{
    public class EnemySpawner : MonoBehaviour
    {
        public Action<EnemyEntity> OnSpawn;

        [SerializeField] private EnemyEntity _enemy;
        [SerializeField] private float _spawnTime = 2f;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private HeroDocument _heroDocument;

        public void Start()
        {
            StartCoroutine(StartSpawn());
        }

        private IEnumerator StartSpawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnTime);
                var spawnPoint = GetRandomPoint();
                var enemy = Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
                
                if (enemy.TryGet(out IFollowComponent followComponent))
                {
                    followComponent.Follow(_heroDocument.Transform);
                }   
                
                OnSpawn?.Invoke(enemy);
            }
        }

        private Transform GetRandomPoint()
        {
            return _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        }
    }
}