using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Target _targetToFollow;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    [SerializeField] private float _spawnInterval = 2f;

    private bool _isSpawn = false;
    private Coroutine _spawnCoroutine;

    private void OnDisable()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
        }
    }

    public void StartSpawn()
    {
        if (_isSpawn)
        {
            return;
        }

        _isSpawn = true;
        _spawnCoroutine = StartCoroutine(SpawnCorutine(_spawnInterval));
    }

    private IEnumerator SpawnCorutine(float delay)
    {
        WaitForSeconds delayTime = new WaitForSeconds(delay);

        while (_isSpawn)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Enemy enemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.Init(_targetToFollow);

            yield return delayTime;
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        int minIndex = 0;
        int maxIndex = _spawnPoints.Count;
        Vector3 position = _spawnPoints[Random.Range(minIndex, maxIndex)].position;

        return position;
    }
}