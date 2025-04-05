using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float minHeight, maxHeight;
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(obstaclePrefab, GetRandomPosition(), Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    Vector2 GetRandomPosition()
    {
        return new Vector2(transform.position.x, Random.Range(minHeight, maxHeight));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
