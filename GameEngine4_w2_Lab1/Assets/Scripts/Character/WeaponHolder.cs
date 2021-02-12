using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [Header("Weapon to Spawn"), SerializeField]
    private GameObject weaponToSpawn;

    [SerializeField] private Transform weaponSocketLocation;

    // Start is called before the first frame update
    void Start()
    {
      GameObject spawnweapon =  Instantiate(weaponToSpawn, weaponSocketLocation.position, weaponSocketLocation.rotation,weaponSocketLocation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
