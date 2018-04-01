﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    private GameObject defenderParent;

    private void Start()
    {
        defenderParent = GameObject.Find("Defenders");
        if (!defenderParent)
        {
            //Debug.Log("No parent, spawning Projectiles parent");
            defenderParent = new GameObject("Defenders");
        }
    }

    private void OnMouseDown()
    {
        Vector2 rawPos = CalculateMousePosition();
        Vector2 snapPos = SnapToGrid(rawPos);
        if (Button.selectedDefender)
        {
            GameObject defender = Instantiate(Button.selectedDefender, snapPos, Quaternion.identity);
            defender.transform.parent = defenderParent.transform;
        }
        else
        {
            Debug.Log("No selected defender to spawn");
        }
    }

    private Vector2 CalculateMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        float mouseX = Camera.main.ScreenToWorldPoint(mousePos).x;
        float mouseY = Camera.main.ScreenToWorldPoint(mousePos).y;
        return new Vector2(mouseX, mouseY);
    }

    private Vector2 SnapToGrid(Vector2 rawPos)
    {
        float newX = Mathf.RoundToInt(rawPos.x);
        float newY = Mathf.RoundToInt(rawPos.y);
        return new Vector2(newX, newY);
    }
}
