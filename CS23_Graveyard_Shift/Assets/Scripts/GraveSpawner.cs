using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GraveSpawner : MonoBehaviour {

    public GameObject gravePrefab;
    public const int numberOfGraves = 5;
    public Vector2 spawnPosition = new Vector2(30, 10);
    public Vector2[] SpawnPoints = new Vector2[numberOfGraves];

    void Start() {
        SpawnGraves();
    }

    void SpawnGraves() {
        for (int i = 0; i < numberOfGraves; i++) {
            Vector2 spawnPos = new Vector2(
                Random.Range(-spawnPosition.x, spawnPosition.x),
                Random.Range(-spawnPosition.y, spawnPosition.y)
            );
            for (int j = 0; j < i; j++) {
                if (Vector2.Distance(spawnPos, SpawnPoints[j]) < 2.0f) {
                    spawnPos = new Vector2(
                        Random.Range(-spawnPosition.x, spawnPosition.x),
                        Random.Range(-spawnPosition.y, spawnPosition.y)
                    );
                    j = -1;
                }
            }
            Instantiate(gravePrefab, spawnPos, Quaternion.identity);
            SpawnPoints[i] = spawnPos;
        }
    }
}