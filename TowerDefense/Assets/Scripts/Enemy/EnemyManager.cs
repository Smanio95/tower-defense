using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Transform[] positions;
    [SerializeField] Transform enemyParent;
    [SerializeField] Enemy[] enemyPrefab;

    [SerializeField] float minSpawnTime = 1;
    [SerializeField] float maxSpawnTime = 5;

    private float spawnTime;
    private float elapsed = 0;
    private readonly List<Enemy> enemyList = new();

    void Start()
    {
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        if (elapsed < spawnTime)
            elapsed += Time.deltaTime;
        else
        {
            elapsed = 0;
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Enemy enemy = RetrieveEnemy(out float height);

        Vector3 initialPos = new(positions[0].position.x, height, positions[0].position.z);
        enemy.transform.SetPositionAndRotation(initialPos, positions[0].rotation);

        enemy.gameObject.SetActive(true);
    }

    Enemy RetrieveEnemy(out float height)
    {
        Enemy enemy;
        int randomIndex = Random.Range(0, enemyList.Count == 0 ? enemyPrefab.Length : enemyList.Count);

        if (enemyList.Count == 0)
        {
            enemy = Instantiate(enemyPrefab[randomIndex], enemyParent);
            height = enemyPrefab[randomIndex].transform.position.y;
            enemy.EM = this;
        }
        else
        {
            enemy = enemyList[randomIndex];
            enemyList.RemoveAt(randomIndex);
            height = enemy.transform.position.y;
        }
        return enemy;
    }

    public Vector3 RetrievePos(float height, ref int currentPos)
    {
        currentPos++;
        return new(positions[currentPos].position.x,
            height,
            positions[currentPos].position.z);
    }

    public void AddEnemy(Enemy enemy) => enemyList.Add(enemy);

}
