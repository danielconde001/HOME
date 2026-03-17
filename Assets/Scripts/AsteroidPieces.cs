using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPieces : MonoBehaviour
{
    float z;

    void Start()
    {
        z = Random.Range(0f, 10f);
    }

    void Update()
    {
        transform.eulerAngles += new Vector3(0 , 0, z);

    }
}
