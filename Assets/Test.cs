using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Test : MonoBehaviour
{
    public Volume Volume;
    [Range(1, 100)]
    public float speed = 50;
    
    public float time = 0;
    
    public bool isStart = false;
    public bool reset = false;
    
    void Update()
    {
        if (reset)
        {
            Volume.weight = 0;
            reset = false;
            isStart = false;
        }
        if (!isStart) return;
        time += Time.deltaTime;
        if (time > 1 && Volume.weight < 1)
        {
            Volume.weight += Time.deltaTime * speed;
        }
        else if (time > 1 && Volume.weight >= 1)
        {
            time = 0;
        }
    }
}
