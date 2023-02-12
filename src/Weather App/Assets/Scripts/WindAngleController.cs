using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WindAngleController : MonoBehaviour
{
    public GameObject origin;

    public Vector3 initialPosition;
    
    private const int NORTH = 0;
    private const int SOUTH = 180;
    private const int EAST = 90;
    private const int WEST = 270;
    private const int NORTHWEST = 315;
    private const int NORTHEAST = 45;
    private const int SOUTHWEST = 225;
    private const int SOUTHEAST = 135;

    public bool rotated = false;

    public WindDirection currentDirection = WindDirection.NONE;


    private void OnEnable()
    {
        transform.localPosition = initialPosition;
        transform.localRotation = Quaternion.identity;
        rotated = false;
        Rotate();
    }

    private void OnDisable()
    {
        transform.localPosition = initialPosition;
        transform.localRotation = Quaternion.identity;
        rotated = false;
    }

    private void Rotate()
    {
        if (!rotated)
        {
            switch (currentDirection)
            {
                case WindDirection.NORTH:
                    transform.RotateAround(origin.transform.position, new Vector3(0, 1, 0), NORTH);
                    break;
                case WindDirection.SOUTH:
                    transform.RotateAround(origin.transform.position, new Vector3(0, 1, 0), SOUTH);
                    break;
                case WindDirection.EAST:
                    transform.RotateAround(origin.transform.position, new Vector3(0, 1, 0), EAST);
                    break;
                case WindDirection.WEST:
                    transform.RotateAround(origin.transform.position, new Vector3(0, 1, 0), WEST);
                    break;
                case WindDirection.NORTHWEST:
                    transform.RotateAround(origin.transform.position, new Vector3(0, 1, 0), NORTHWEST);
                    break;
                case WindDirection.NORTHEAST:
                    transform.RotateAround(origin.transform.position, new Vector3(0, 1, 0), NORTHEAST);
                    break;
                case WindDirection.SOUTHWEST:
                    transform.RotateAround(origin.transform.position, new Vector3(0, 1, 0), SOUTHWEST);
                    break;
                case WindDirection.SOUTHEAST:
                    transform.RotateAround(origin.transform.position, new Vector3(0, 1, 0), SOUTHEAST);
                    break;
                default:
                    transform.RotateAround(origin.transform.position, new Vector3(0, 1, 0), Random.Range(0, 359));
                    break;
            }

            rotated = true;

        }
    }
    
    
}

public enum WindDirection
{
    NONE, //0
    NORTH, //1
    SOUTH, //2
    EAST, //3
    WEST,//4
    NORTHWEST, //5
    NORTHEAST, //6
    SOUTHWEST, //7
    SOUTHEAST, //8
}
