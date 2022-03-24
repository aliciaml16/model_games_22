using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colors : MonoBehaviour
{
     private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        Debug.Log("Click!");
        _renderer.material.color =
            _renderer.material.color == Color.red ? Color.blue : Color.red;
        
    }
}
