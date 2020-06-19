using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public float growDistance = 25f;
    public bool isGrown = false;

    private void OnEnable()
    {
        PlayerController.OnPlayerMove += PlayerController_OnPlayerMove;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerMove -= PlayerController_OnPlayerMove;
    }

    private void Start()
    {
        PlayerController_OnPlayerMove(Vector3.zero);
    }

    private void PlayerController_OnPlayerMove(Vector3 velocityChange)
    {
        float distance = (transform.position).magnitude;

        if (distance < growDistance)
        {
            if (!isGrown)
                MakeGrow();
        }
        else
        {
            if (isGrown)
                MakeShrink();
        }
    }

    /// <summary>
    /// aqui puede implementar los metodos que hacen crecer a las palmeras
    /// </summary>
    private void MakeShrink()
    {
    }

    private void MakeGrow()
    {
    }

    // Start is called before the first frame update
}