using UnityEngine;
using System.Collections;

public class SelectionMenu : MonoBehaviour
{
    public Button selected;
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
        selected.state = (State)state;
    } 
}
