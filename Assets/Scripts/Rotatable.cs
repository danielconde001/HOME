using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatable : MonoBehaviour
{
    float num;
	[SerializeField] bool canRotate = true;

    private void Start() 
    {
        num = UnityEngine.Random.Range(-1f, 1f);
    }

    private void Update()
    {
        transform.Rotate(0, 0, num);
    }
}
