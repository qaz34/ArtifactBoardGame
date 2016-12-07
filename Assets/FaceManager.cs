using UnityEngine;
using System.Collections;

public class FaceManager : MonoBehaviour
{
    public int buttons;
    public bool faceDone;
    bool first = true;
    public Material doneMat;
    public Material wrongMat;
    public Material transMat;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void LateUpdate()
    {

        int i = 0;
        foreach (Button button in GetComponentsInChildren<Button>())
        {
            if (button.correct)
            {
                i++;
                button.gameObject.GetComponent<MeshRenderer>().material = doneMat;
            }
            else
                button.gameObject.GetComponent<MeshRenderer>().material = wrongMat;
        }
        if (i == buttons)
        {
            faceDone = true;
            GetComponent<MeshRenderer>().material = doneMat;
        }
        else
        {
            faceDone = false;
            GetComponent<MeshRenderer>().material = transMat;
        }
        if (first)
        {
            if (faceDone)
            {
                foreach (Button button in GetComponentsInChildren<Button>())
                {
                    Debug.Log("Event");
                    button.SetState();
                }
            }
            else
            {
                first = false;
            }

        }
    }
}
