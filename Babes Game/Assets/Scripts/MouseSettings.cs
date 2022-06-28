using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSettings : MonoBehaviour
{
    public bool resetMouse;
    private bool control;

    public Texture2D cursorTexture;
    private Vector2 cursorHotSpot;

    public void Start()
    {

        cursorHotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHotSpot, CursorMode.Auto);

        // preset mouse settings

        resetMouse = false;
        control = false;
    }

    private void Update()
    {
        if (control)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            control = false;
        }

        if (resetMouse) //reset mouse when buying a tower called from other function
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            control = true;
        }
    }


}
