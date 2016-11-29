using UnityEngine;
using System.Collections;

public class SelectionMenu : MonoBehaviour
{
    public Button selected;
    public bool faceLock = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Select") || Input.GetButtonDown("Move"))
        {
            Destroy(this.gameObject, Time.deltaTime * 8);
        }

    }
    public void SetState(int state)
    {
        if (!selected.transform.parent.GetComponent<FaceManager>().faceDone || !faceLock)
            selected.state = (State)state;
    }
}
