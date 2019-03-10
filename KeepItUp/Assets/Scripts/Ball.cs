using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < 0.0f)
        {
            transform.position= new Vector3(Random.Range(-3.0f, 8.0f), Random.Range(12.0f, 25.0f), Random.Range(-2.0f, 12.0f));
        }
    }
}
