using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingController : MonoBehaviour
{
    public Light front;

    public Light back;

    public Color[] defaults = { new Color(6, 171, 255), new Color(247, 6, 255) };
    
    public Color[] snow = { new Color(142, 183, 237), new Color(3, 104, 148) };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColours(Color[] colours){

        front.color = colours[0];
        back.color = colours[1];
    }
}
