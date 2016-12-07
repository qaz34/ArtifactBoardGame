using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
[CustomEditor(typeof(Location))]
public class Pathing : Editor
{
    Location first, connection;
    
    public void OnEnable()
    {
        first = null;
        connection = null;
        SceneView.onSceneGUIDelegate += SelectLocation;
    }
    void SelectLocation(SceneView sceneView)
    {
        Event e = Event.current;
        Ray ray = Camera.current.ScreenPointToRay(new Vector2(e.mousePosition.x, Camera.current.pixelHeight - e.mousePosition.y));
        RaycastHit hit;
        if (e.type == EventType.KeyDown)
            if (e.keyCode == KeyCode.A)
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (first == null && hit.transform.GetComponent<Location>() != first)
                    {
                        first = hit.transform.GetComponent<Location>();
                    }
                    else if (connection == null && hit.transform.GetComponent<Location>() != first)
                    {
                        connection = hit.transform.GetComponent<Location>();
                    }
                }
            }
        if (first != null && connection != null)
        {
            first.connectedLands.Add(connection);
            first = null;
            connection = null;
        }
    }

    //// Use this for initialization
    //void Enable()
    //{
    //    first = null;
    //    connection = null;
    //}

    //void OnGUI()
    //{
    //    Debug.Log("asdf");
    //    Event e = Event.current;
    //    Ray ray = Camera.current.ScreenPointToRay(new Vector2(e.mousePosition.x, Camera.current.pixelHeight - e.mousePosition.y));
    //    RaycastHit hit;
    //    if (first != null && connection != null)
    //    {
    //        first.connectedLands.Add(connection);
    //        first = null;
    //        connection = null;
    //    }
    //    if (Physics.Raycast(ray, out hit, Mathf.Infinity) && e.keyCode == KeyCode.A)
    //    {
    //        if (first != null)
    //        {
    //            first = hit.transform.GetComponent<Location>();
    //        }
    //        else if (connection != null)
    //        {
    //            connection = hit.transform.GetComponent<Location>();
    //        }
    //    }
    //}
}