using UnityEngine;
using System.Collections.Generic;
using System.Linq;
[ExecuteInEditMode]
public class Location : MonoBehaviour
{
    public List<Location> connectedLands = new List<Location>();
    public bool accessable;
    public Material mat;
    private void OnDrawGizmos()
    {
        var uniqueItemsList = connectedLands.Distinct().ToList();
        connectedLands = uniqueItemsList;
        foreach (Location loc in connectedLands)
        {
            Vector3 dir = loc.transform.position - transform.position;
            float dist = Vector3.Distance(transform.position, loc.transform.position);
            DrawArrow.ForGizmo(transform.position, dir.normalized * dist, Color.blue);
        }
    }
    void OnRenderObject()
    {
        mat.SetPass(0);
        GL.PushMatrix();
        GL.LoadProjectionMatrix(Camera.main.projectionMatrix);
        GL.Begin(GL.LINES);
        foreach (Location loc in connectedLands)
        {
            GL.Vertex(transform.position);
            GL.Vertex(loc.transform.position);

            Vector3 right = Quaternion.LookRotation(loc.transform.position - transform.position) * Quaternion.Euler(0, 180 + 20, 0) * new Vector3(0, 0, 1);
            Vector3 left = Quaternion.LookRotation(loc.transform.position - transform.position) * Quaternion.Euler(0, 180 - 20, 0) * new Vector3(0, 0, 1);

            Vector3 pos = new Vector3(loc.transform.position.x, loc.transform.position.y, loc.transform.position.z );
            GL.Vertex(pos);
            GL.Vertex(pos + right /2);
            GL.Vertex(pos);
            GL.Vertex(pos + left / 2);
        
        }
        GL.End();
        GL.PopMatrix();
    }
}
