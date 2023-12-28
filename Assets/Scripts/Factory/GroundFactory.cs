using Assets.Scripts.GameManagment;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Factory
{
    public class GroundFactory : MonoBehaviour
    {
        [SerializeField] private CreateCollider _createCollider;
        [SerializeField] private Game _game;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private List<GameObject> _groundPrefabs = new();

        private int _groundsToDisable = 2;
        private int _countToDisable;

        private readonly float _spawnIntervalX = 40f;
        private readonly Queue<GameObject> _groundPool = new();

        private void OnEnable()
        {
            _createCollider.Collided += SpawnGround;
            _game.GameStarted += StartGame;
        }

        private void OnDisable()
        {
            _createCollider.Collided -= SpawnGround;
            _game.GameStarted -= StartGame;
        }


        private void Awake()
        {
            _countToDisable = _groundsToDisable;

            InitializeGroundPool();
        }

        private void StartGame()
        {
            _spawnPoint.position = Vector3.zero;
            SpawnGround();
            SpawnGround();
        }

        private void InitializeGroundPool()
        {
            foreach (var prefab in _groundPrefabs)
            {
                GameObject obj = Instantiate(prefab, _spawnPoint.position, Quaternion.identity);
                obj.SetActive(false);
                _groundPool.Enqueue(obj);
            }
        }

        private void SpawnGround()
        {
            GameObject groundToSpawn = GetPooledGround();
            if (groundToSpawn != null)
            {
                groundToSpawn.SetActive(true);
                groundToSpawn.transform.position = _spawnPoint.position;
                _spawnPoint.position += new Vector3(_spawnIntervalX, 0f, 0f);
                DisableOldGround();
            }
        }

        private GameObject GetPooledGround()
        {
            GameObject ground = _groundPool.Dequeue();
            _groundPool.Enqueue(ground);
            return ground;
        }

        private void DisableOldGround()
        {
            _countToDisable--;
            if (_countToDisable <= 0)
            {
                GameObject groundToDisable = _groundPool.Dequeue();
                groundToDisable.SetActive(false);
                _groundPool.Enqueue(groundToDisable);
                _countToDisable = _groundsToDisable;
            }
        }
    }
}