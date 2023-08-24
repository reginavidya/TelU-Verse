using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public GameObject objRadius;
    private Color32 color1 = new Color32(217, 0, 0, 255);
    private Color32 color = new Color32(0, 230, 60, 255);
    private Renderer _renderRadius;

    private void Start()
    {
        _renderRadius = objRadius.GetComponent<Renderer>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        print("Masuk Area AR");
        _renderRadius.material.SetColor("_TintColor", color);
    }
    public void OnCollisionExit(Collision collision)
    {
        print("Keluar Area AR");
        _renderRadius.material.SetColor("_TintColor", color1);
    }
}
