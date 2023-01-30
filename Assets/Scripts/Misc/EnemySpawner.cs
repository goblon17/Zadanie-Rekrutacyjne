using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private uint nuberOfEnemies;
    [SerializeField]
    private BoundsSizeController bounds;

    private void Start()
    {
        for (int i = 0; i < nuberOfEnemies; i++)
        {
            Vector2 position = new Vector2 ((Random.value * 2 - 1) / 2, (Random.value * 2 - 1) / 2) * bounds.Size;
            Instantiate(enemyPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
        }
    }
}
