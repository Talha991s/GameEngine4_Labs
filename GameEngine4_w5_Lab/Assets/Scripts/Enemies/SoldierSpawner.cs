using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoldierSpawner : MonoBehaviour
{
    [SerializeField] private int NumOfSoldierSpawn;
    [SerializeField] private GameObject[] Enemyprefab;
    [SerializeField] private SpawnerVolume[] spawnerVolumes;

    private GameObject FollowGameObject;

    // Start is called before the first frame update
    void Start()
    {
        FollowGameObject = GameObject.FindGameObjectWithTag("Player");

        for(int index =0; index < NumOfSoldierSpawn; index++)
        {
            SpawnSoldier();
        }
    }
    private void SpawnSoldier()
    {
        GameObject EnemyToSpawn = Enemyprefab[Random.Range(0, Enemyprefab.Length)];
        SpawnerVolume spawnVolume = spawnerVolumes[Random.Range(0, spawnerVolumes.Length)];

        if(FollowGameObject)
        {
            GameObject enemy = Instantiate(EnemyToSpawn, spawnVolume.GetPositionInBound(),
    spawnVolume.transform.rotation);

            enemy.GetComponent<ZombieComponent>().Initialize(FollowGameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
