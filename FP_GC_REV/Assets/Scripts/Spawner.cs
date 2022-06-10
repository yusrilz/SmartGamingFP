using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float interval = 3.5f;
    private int[] posX = { 10, -10, 10, 10, -10, -10 };
    private int[] posY = { 4, 2, 0 };

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(interval, enemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(posX[Random.Range(0, 5)], posY[Random.Range(0, 3)], 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
