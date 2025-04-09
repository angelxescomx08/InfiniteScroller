using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float minHeight, maxHeight;
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObject prefab;
    [SerializeField] private float minSpawnTime = 0.6f;
    [SerializeField] private float timeDecreaseStep = 0.2f;
    [SerializeField] private int spawnCountToDecreaseTime = 5;
    private int spawnCount = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(prefab, GetRandomPosition(), Quaternion.identity);
            spawnCount++;
            DecreaseSpawnTime();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void DecreaseSpawnTime()
    {
        if (spawnCount % spawnCountToDecreaseTime == 0)
        {
            spawnTime -= timeDecreaseStep;
            if (spawnTime < minSpawnTime)
            {
                spawnTime = minSpawnTime;
            }
        }
    }

    Vector2 GetRandomPosition()
    {
        return new Vector2(transform.position.x, Random.Range(minHeight, maxHeight));
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
    }
}
