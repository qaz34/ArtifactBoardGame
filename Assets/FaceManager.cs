using UnityEngine;
using System.Collections;

public class FaceManager : MonoBehaviour
{
    public int faces;
    public bool faceDone;
    public Material doneMat;
    public Material wrongMat;
    public Material transMat;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
        if (i == faces)
        {
            faceDone = true;
            GetComponent<MeshRenderer>().material = doneMat;
        }
        else
        {
            faceDone = false;
            GetComponent<MeshRenderer>().material = transMat;
        }

    }
}
