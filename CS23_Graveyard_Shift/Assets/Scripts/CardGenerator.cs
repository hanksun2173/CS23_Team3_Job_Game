// using System.Collections.Generic;
// using System.Collections;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;

// public class CardGenerator : MonoBehaviour {

//     // public GameObject gravePrefab;
//     // public Vector2 spawnPosition = new Vector2(30, 10);
//     // public Vector2[] SpawnPoints = new Vector2[numberOfGraves];

//     public GameObject cardPrefab;
//     public int handSize = 5;

//     void Start() {
//         for (int i = 0; i < numberOfGraves; i++) {

//             int cardVal = Random.Next(0, 11);
//             int cardSuit = Random.Next(0, 3);

            

//             for (int j = 0; j < i; j++) {
//                 if (Vector2.Distance(spawnPos, SpawnPoints[j]) < 10.0f) {
//                     spawnPos = new Vector2(
//                         Random.Range(-spawnPosition.x, spawnPosition.x),
//                         Random.Range(-spawnPosition.y, spawnPosition.y)
//                     );
//                     j = -1;
//                 }
//             }
//             Instantiate(gravePrefab, spawnPos, Quaternion.identity);
//             SpawnPoints[i] = spawnPos;
//         }
//     }
// }