using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject m_object = null;
    [SerializeField] int m_size = 10;
    [SerializeField] bool m_grow = true;

    Queue<GameObject> m_pool = new Queue<GameObject>();
    int m_id = 1;

    void Start()
    {
        Grow(m_size);
    }

    public GameObject Get(Vector3 position, Quaternion rotation, Transform parent = null)
    {
        if (m_pool.Count == 0 && m_grow)
        {
            Grow(m_size);
        }
        GameObject go = m_pool.Dequeue();
        go.transform.position = position;
        go.transform.rotation = rotation;
        go.transform.parent = parent;
        return go;
    }

    public void Return(GameObject go)
    {
        m_pool.Enqueue(go);
        go.transform.parent = transform;
        go.SetActive(false);
    }

    void Grow(int size)
    {
        for(int i = 0; i<size; i++)
        {
            GameObject go = Instantiate(m_object, transform);
            go.name = m_object.name + m_id++;
            m_pool.Enqueue(go);
        }
    }
}
