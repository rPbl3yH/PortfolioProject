using Sirenix.OdinInspector;
using UnityEngine;

namespace SaveLoad.GameManagement
{
    public class GameSaver
    {
        private readonly IGameMediator[] _gameMediators;
        private readonly GameRepository _gameRepository;

        public GameSaver(IGameMediator[] gameMediators, GameRepository gameRepository)
        {
            _gameMediators = gameMediators;
            _gameRepository = gameRepository;
        }

        [ShowInInspector]
        public void Save()
        {
            foreach (var gameMediator in _gameMediators)
            {
                gameMediator.SaveData(_gameRepository);
            }
            
            _gameRepository.SaveState();
            Debug.Log("Save");
        }

        [ShowInInspector]
        public void Load()
        {
            _gameRepository.LoadState();
            
            foreach (var gameMediator in _gameMediators)
            {
                gameMediator.SetupData(_gameRepository);    
            }
            
            Debug.Log("Load");
        }
    }
}