using UnityEngine;
using System.Collections;

public class CubeBehaviour : MonoBehaviour
{
    void Start()
    {
        var graph = GetComponent<GraphComponent>();
        if (null != graph)
        {
            graph.SetLineColor("y", new Color(1.0f, 0.0f, 0.0f, 0.75f));
        }
    }

    void Update ()
    {
        var pos = transform.position;
        pos.y = Mathf.Sin(Time.time) * 3.0f;
        transform.position = pos;
    }

    void FixedUpdate()
    {
        var graph = GetComponent<GraphComponent>();
        if( null != graph )
        {
            graph.AddValue("y", transform.position.y);
        }
    }
}
