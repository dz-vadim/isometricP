using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public static readonly string[] staticDirection =
        {"Static N", "Static NW", "Static W", "Static SW", 
        "Static S", "Static SE", "Static E", "Static NE"};

    public static readonly string[] runDirection =
        {"Run N", "Run NW", "Run W", "Run SW",
        "Run S", "Run SE", "Run E", "Run NE"};

    Animator animator;
    int lastDirection;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        animator.Play("Static E");
    }
    public void SetDirection(Vector2 direction)
    {
        string[] directionArray = null;
        if (direction.magnitude < 0.01)
        {
            directionArray = staticDirection;
        }
        else
        {
            directionArray = runDirection;
            lastDirection = DirectionToIndex(direction);
        }
        animator.Play(directionArray[lastDirection]);
    }

    private int DirectionToIndex(Vector2 direction)
    {
        Vector2 norDir = direction.normalized;
        float step = 360 / 8; // 45
        float offset = step / 2; //22.5 

        float angle = Vector2.SignedAngle(Vector2.up, norDir);
        angle += offset;

        if (angle < 0)
        {
            angle += 360;
        }
        
        float stepCount = angle / step; 

        return Mathf.FloorToInt(stepCount);
    }
}
