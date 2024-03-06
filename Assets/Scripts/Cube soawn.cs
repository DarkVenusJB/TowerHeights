using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubesoawn : MonoBehaviour
{
    [SerializeField] private GameObject[] obj;
    [SerializeField] private float SpawnTime;
    [SerializeField] private float BlockRange;

    private bool CanSpawn = true;
    private bool IsDrop = false;
    private GameObject Cube;

    private void Start()
    {
        Spawn();

    }

    private void Update()
    {
        transform.position = new Vector3 (-Mathf.PingPong(Time.time, BlockRange), transform.position.y, Mathf.PingPong(Time.time, BlockRange)) ;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Drop();
            StartCoroutine(CubeSpawner());
        }
    }

    private void Spawn()
    {
        int random = UnityEngine.Random.Range(0, obj.Length - 1);
        Cube = Instantiate(obj[random], transform.position, transform.rotation);
        Cube.transform.SetParent(transform);
    }

    private void Drop()
    {
        Cube.transform.parent = null;
        Rigidbody rbCube = Cube.GetComponent<Rigidbody>();
        rbCube.useGravity = true;
    }

    private IEnumerator CubeSpawner()
    {
        //CanSpawn = false;
        yield return new WaitForSeconds(SpawnTime);
       // CanSpawn = true;
       Spawn();
    }
}
