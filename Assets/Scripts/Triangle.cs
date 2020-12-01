using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    Mesh mesh;
    void Awake()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Triangle";
        Vector3[] vertices = new Vector3[3];
        vertices[0].Set(0.5f, -0.5f, 2.0f);
        vertices[1].Set(-0.5f, -0.5f, 2.0f);
        vertices[2].Set(0.0f, 0.5f, 2.0f);
        mesh.SetVertices(vertices);
        int[] indexes = new int[3];
        indexes[0] = 0;
        indexes[1] = 1;
        indexes[2] = 2;
        mesh.SetTriangles(indexes, 0);
    }
}
