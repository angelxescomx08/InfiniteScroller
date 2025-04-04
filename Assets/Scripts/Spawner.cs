using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
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
            Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
