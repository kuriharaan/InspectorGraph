using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace GraphWindow
{
    [CustomEditor(typeof(GraphComponent))]
    public class GraphInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            GraphComponent graphComponent = target as GraphComponent;

            graphComponent.Scale      = EditorGUILayout.FloatField("Scale", graphComponent.Scale);
            graphComponent.BufferSize = EditorGUILayout.IntField("Buffer Size", graphComponent.BufferSize);

            var rect = GUILayoutUtility.GetRect(Mathf.Max(50.0f, Screen.width - 100.0f), 200.0f);

            if (Event.current.type != EventType.Repaint)
            {
                return;
            }


            UnityEditor.Graphs.Styles.graphBackground.Draw(rect, false, false, false, false);

            LineMaterial.Material.SetPass(0);

            GL.PushMatrix();
            GL.Begin(GL.LINES);

            float left   = rect.position.x;
            float right  = rect.position.x + rect.width;
            float middle = rect.position.y + rect.height * 0.5f;

            GL.Color(LineColor.AxisColor);
            DrawLine(new Vector2(left, middle), new Vector2(right, middle));


            foreach (var kvp in graphComponent.Buffers)
            {
                var buff = kvp.Value;

                GL.Color(new Color(1.0f, 0.0f, 0.0f, 0.75f));
                for (int i = 0; i < buff.Count - 1; ++i)
                {
                    float x0 = right - (buff.Count - i);
                    float x1 = x0 + 1.0f;

                    if (x0 < rect.position.x)
                    {
                        continue;
                    }

                    float y0 = -buff[i]     * graphComponent.Scale + middle;
                    float y1 = -buff[i + 1] * graphComponent.Scale + middle;

                    y0 = Mathf.Max( Mathf.Min(y0, rect.position.y + rect.height), rect.position.y);
                    y1 = Mathf.Max( Mathf.Min(y1, rect.position.y + rect.height), rect.position.y);

                    DrawLine( new Vector2(x0, y0), new Vector2(x1, y1) );
                }
            }

            GL.End();
            GL.PopMatrix();
        }

        private void DrawLine(Vector2 p1, Vector2 p2)
        {
            GL.Vertex(p1);
            GL.Vertex(p2);
        }
    }
}