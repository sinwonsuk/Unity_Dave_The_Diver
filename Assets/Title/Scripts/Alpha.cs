using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha : MonoBehaviour
{
    public Renderer objectRenderer;
    public float transparency = 0.5f; // 0은 완전 투명, 1은 불투명

    void Start()
    {
        if (objectRenderer == null)
        {
            objectRenderer = GetComponent<Renderer>();
        }

        SetTransparency(transparency);
    }

    public void SetTransparency(float alpha)
    {
        Color color = objectRenderer.material.color;
        color.r = 1.0f;
        color.g = 1.0f;
        color.b = 1.0f;
        color.a = 0.5f;
        objectRenderer.material.color = color;
    }
}
