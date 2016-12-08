using UnityEngine;
using System.Collections.Generic;
using System.Linq;
[ExecuteInEditMode]
public class Location : MonoBehaviour
{
    public List<Location> connectedLands = new List<Location>();
    public bool accessable;
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
}
