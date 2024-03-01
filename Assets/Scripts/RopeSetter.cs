using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSetter : NetworkClass
{
    // Start is called before the first frame update

    public Spider[] rope;
    private int index = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (!isOffline && !isMine) return;
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            index = index > rope.Length - 1 ? 0 : index;
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rope[index].setStart(worldPos);
            index++;
        }
    }
}
