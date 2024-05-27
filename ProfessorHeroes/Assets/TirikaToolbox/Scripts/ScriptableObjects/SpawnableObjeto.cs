using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New SpawnableObjeto", menuName = "TIRIKA/SpawnableObjeto", order = 7)]
public class SpawnableObjeto : GenericObject
{
    public GameObject prefab;
    public Vector3 spawnPosition;
    public Quaternion spawnRotation;
}
