using System.Collections.Generic;
using UnityEngine;

public class EnterPoint : MonoBehaviour
{
    [SerializeField] private List<Spawner> _spawners = new List<Spawner>();

    private void Start()
    {
        StartAllSawners();
    }

    private void StartAllSawners()
    {
        foreach (Spawner spawner in _spawners)
        {
            spawner.StartSpawn();
        }
    }
}