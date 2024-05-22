using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public float delay;
    public GameObject prefab;
    public Transform parent;
    public Transform position;
    private float timer;
    private GameObject spawned;
    void Start()
    {
        timer = delay;
    }
        
    void Update()
    {
        if(timer < 0 && spawned == null)
        {
            Spawn();
            timer = delay;
        }
        timer -= Time.deltaTime;
    }
    void Spawn()
    {
        spawned = Instantiate(prefab, position.position, position.rotation, parent);
    }
}
