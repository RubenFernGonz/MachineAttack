using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaCursor : MonoBehaviour
{
    bool active = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            MouseCursor.instance.ChangeCursor(active);
            active = !active;
        }
    }
}
