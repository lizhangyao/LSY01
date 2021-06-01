using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public float spawnTime = 5f;
    public float spawnDelay = 3f;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    void Spawn()
    {
        int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
        foreach (ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
        {
            p.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
