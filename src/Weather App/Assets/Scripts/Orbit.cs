using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float speed;

    public GameObject origin;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(origin.transform.position, new Vector3(0, 1, 0), speed * Time.deltaTime);
    }
}
