using System;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Diagnostics.DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class PlayerController : MonoBehaviour
{
    private static object GetDebuggerDisplay()
    {
        throw new NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Debug.Log("Mouse was pressed");
        }
    }
