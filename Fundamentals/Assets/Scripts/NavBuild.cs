using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavBuild : MonoBehaviour
{
    [SerializeField] NavMeshSurface[] m_surfaces = null;
    [SerializeField] bool m_buildOnUpdate = true;
    public void Build()
    {
        foreach(var surface in m_surfaces)
        {
            surface.RemoveData();
            surface.BuildNavMesh();
        }
    }

    void Update()
    {
        if (m_buildOnUpdate)
        {
            Build();
        }
    }
}
