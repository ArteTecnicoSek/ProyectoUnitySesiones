using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class VertexInfo : MonoBehaviour
{
    public Vector3[] vertexPositions;
    public Color[] vertexCOlor;

    // Start is called before the first frame update
    private void Start()
    {
    }

    private void OnEnable()
    {
        GetVertexInfo();
    }

    private void GetVertexInfo()
    {
        vertexPositions = GetComponent<MeshFilter>().mesh.vertices;
        vertexCOlor = GetComponent<MeshFilter>().mesh.colors;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}