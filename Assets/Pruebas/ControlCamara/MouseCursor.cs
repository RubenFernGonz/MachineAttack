using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public Texture2D cursorType;

    public static MouseCursor instance;

    private void Awake()
    {
        instance = this;
    }

    //Llamada true pone eel cursor de diana, False pone el cursor por defecto
    public void ChangeCursor(bool usingTarget)
    {
        if (!usingTarget)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            return;
        }
        Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
    }
}
