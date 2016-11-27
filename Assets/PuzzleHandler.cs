using UnityEngine;
using System.Collections;

public class PuzzleHandler : MonoBehaviour
{
    public SelectionMenu menu;
    public float speed;
    public bool puzzleSolved;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Move"))
        {
            Vector3 axis = new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0);
            axis *= speed * Time.deltaTime;
            transform.Rotate(axis, Space.World);
        }
        if (Input.GetButtonDown("Select"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
            {
                if (hit.collider.tag == "Button")
                {
                    Vector3 offset = new Vector3(1, 0, -1);
                    SelectionMenu selMenu = Instantiate<SelectionMenu>(menu);
                    selMenu.transform.position = hit.collider.transform.position + offset;
                    selMenu.selected = hit.collider.gameObject.GetComponent<Button>();
                }
            }
        }
        int i = 0;
        foreach (FaceManager face in GetComponentsInChildren<FaceManager>())
        {
            if (face.faceDone)
                i++;
            else
                break;
        }
        if (i == 6)
            puzzleSolved = true;
        else
            puzzleSolved = false;
    }
}
