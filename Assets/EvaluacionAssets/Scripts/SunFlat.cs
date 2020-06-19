using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SunFlat : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1f);
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 10);
    }

    // Update is called once per frame

    private void UpdateSunDirection()
    {
        ////aqui usted actualiza la direccion de la luz del sol en todos los shaders que se vean afectados
    }

    private void Update()
    {
        UpdateSunDirection();
    }
}