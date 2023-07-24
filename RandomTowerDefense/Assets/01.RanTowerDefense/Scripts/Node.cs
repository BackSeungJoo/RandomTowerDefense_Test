using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color StartColor;
    public Color SelectColor;
    public Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
    }

    private void OnMouseDown()
    {
       // rend.material.color = SelectColor;

    }

    private void OnMouseUp()
    {
        rend.material.color = SelectColor;
    }
}
