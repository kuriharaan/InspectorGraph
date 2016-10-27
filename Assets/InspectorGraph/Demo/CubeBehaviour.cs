using UnityEngine;
using System.Collections;

public class CubeBehaviour : MonoBehaviour
{
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
            graph.AddValue("position_y", transform.position.y);
        }
    }
}
