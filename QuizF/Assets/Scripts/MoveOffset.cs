﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffset : MonoBehaviour
{
    private Material materialBack;
    private float offset;
    public bool frezz;
    public float velocity;


    private void Start()
    {
        frezz = false;
        materialBack = GetComponent<Renderer>().material;
    }

    private void FixedUpdate()
    {
        if (!frezz)
            offset += 0.001f;
        materialBack.SetTextureOffset("_MainTex", new Vector2(offset * velocity, 0));
    }
}
