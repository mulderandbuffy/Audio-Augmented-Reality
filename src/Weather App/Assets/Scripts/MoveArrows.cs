using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrows : MonoBehaviour
{
    public float distance;

    public float speed;
    // Start is called before the first frame update

    private bool _movingUp = true;
    private float _distanceMoved = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_distanceMoved >= distance)
        {
            _movingUp = !_movingUp;
            _distanceMoved = 0;
        }

        if (_movingUp)
        {
            transform.position += new Vector3(0, speed, 0);
            _distanceMoved += speed;
        }
        else
        {
            transform.position += new Vector3(0, -speed, 0);
            _distanceMoved += speed;
        }

        

    }
}
