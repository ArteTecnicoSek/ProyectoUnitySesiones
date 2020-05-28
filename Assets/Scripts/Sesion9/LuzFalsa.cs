using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LuzFalsa : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 100f);
        Gizmos.DrawSphere(transform.position, .2f);
    }

    private void LightUnlitShader()
    {
        Shader.SetGlobalVector("lightDirection", transform.forward);
    }

    // Update is called once per frame
    [ExecuteInEditMode]
    private void Update()
    {
        LightUnlitShader();
    }
}