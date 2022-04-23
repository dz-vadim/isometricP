using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath path;
    public SpriteRenderer renderer;

    void Update()
    {
        if(path.desiredVelocity.x >= 0.01f)
        {
            renderer.flipX = true;
        } else if (path.desiredVelocity.x <= -0.01f)
        {
            renderer.flipX = false;
        }
    }
}
