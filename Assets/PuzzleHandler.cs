using UnityEngine;
using System.Collections;

public class PuzzleHandler : MonoBehaviour
{
    public SelectionMenu menu;
    public float speed;
    public float snapSpeed;
    public bool puzzleSolved;
    bool rotating = false;
    Transform world;
    Quaternion oldRotation;
    Quaternion newRotation;
    float alpha; // between 0 (at oldRot) and 1 (at newRot)

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
        else if ((Input.GetButtonDown("Vertical") || Input.GetButtonDown("Horizontal")) && !rotating)
        {
            Vector3 input = new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
            var vec = transform.eulerAngles;
            vec.x = Mathf.Round(vec.x / 90) * 90;
            vec.y = Mathf.Round(vec.y / 90) * 90;
            vec.z = Mathf.Round(vec.z / 90) * 90;          
            Quaternion snapped = Quaternion.Euler(vec);

            // transform.eulerAngles = vec;
            
            //rotating = true;
            //transform.Rotate(input * 90, Space.World);

            // start a rotation
            rotating = true;
            alpha = 0;
            oldRotation = transform.rotation;
            newRotation = Quaternion.Euler(input * 90) * snapped;

        }

        if (rotating && alpha < 1)
        {
            alpha += snapSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(oldRotation, newRotation, alpha);
        }
        else
        {
            rotating = false;
        }

        //if (Vector3.Distance(transform.eulerAngles, endPos) >= 1)
        //    transform.Rotate(rotation, 90 * Time.deltaTime, Space.World);
        //else
        //{
        //    transform.eulerAngles = endPos;
        //    rotating = false;
        //}

        if (Input.GetButtonDown("Select"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
            {
                if (hit.collider.tag == "Button")
                {
                    Vector3 offset = new Vector3(.2f, 0, 0);
                    SelectionMenu selMenu = Instantiate<SelectionMenu>(menu);
                    selMenu.transform.SetParent(GameObject.FindGameObjectWithTag("MenuOverlay").transform);
                    selMenu.transform.position = Camera.main.WorldToScreenPoint(hit.collider.transform.position + offset);
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
