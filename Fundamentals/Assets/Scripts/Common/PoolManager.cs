using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    [System.Serializable]
    public class PoolDefinition
    {
        public string id;
        public ObjectPool pool;
    }

    public List<PoolDefinition> m_definitions = null;
    public Dictionary<string, ObjectPool> pools { get; set; } = new Dictionary<string, ObjectPool>();

    void Start()
    {
        foreach(var definition in m_definitions)
        {
            pools[definition.id] = definition.pool;
        }
    }
}
