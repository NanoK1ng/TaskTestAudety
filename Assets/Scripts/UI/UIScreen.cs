using Assets.Scripts.GameManagment;
using System;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UIScreen : MonoBehaviour
    {
        [SerializeField] private Game _game;
        [SerializeField] private GameObject _screenGameOver;
        [SerializeField] private GameObject _screenStartGame;

        private void OnEnable()
        {
            _game.OnGameOver += OnScreenGameOver;
            _game.GameStarted += GameStart;
        }


        private void OnDisable()
        {
            _game.OnGameOver -= OnScreenGameOver;
            _game.GameStarted -= GameStart;
        }

        private void Awake()
        {
            _screenGameOver.SetActive(false);
            _screenStartGame.SetActive(true);
        }

        private void GameStart()
        {
            _screenStartGame.SetActive(false);
            _screenGameOver.SetActive(false);
        }

        private void OnScreenGameOver()
        {
            _screenGameOver.SetActive(true);
        }
    }
}