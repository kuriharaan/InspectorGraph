using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GraphComponent : MonoBehaviour
{
    Dictionary<string, List<float>> buffers = new Dictionary<string, List<float>>();

    public Dictionary<string, List<float>> Buffers { get { return buffers; } }
    public float Scale = 1.0f;
    public int BufferSize = 128;

    public void AddValue(string key, float val)
    {
        if (buffers.ContainsKey(key))
        {
            buffers[key].Add(val);
        }
        else
        {
            var list = new List<float>();
            list.Add(val);
            buffers.Add(key, list);
        }

        while( buffers[key].Count > BufferSize )
        {
            buffers[key].RemoveAt(0);
        }
    }

    void Start()
    {
    }
}
