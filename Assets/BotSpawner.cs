using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{

    [SerializeField] private int gameDifficulty = 1;
    [SerializeField] private float spawnDuration = 5f;
    [SerializeField] private GameObject botPrefab;
    [SerializeField] private float spawnRadius = 10f;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnBot());
    }

    private IEnumerator SpawnBot()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDuration);

            Vector3 spawnPos = GetRandomSpawnPos();
            Instantiate(botPrefab, spawnPos, Quaternion.identity);
        }
    }

    private Vector3 GetRandomSpawnPos()
    {
        Vector2 randomDirection = UnityEngine.Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPos = new Vector3(randomDirection.x, 0, randomDirection.y) + player.position;
        return spawnPos;
    }

}
