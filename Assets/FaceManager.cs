using UnityEngine;
using System.Collections;

public class FaceManager : MonoBehaviour
{
    public bool faceDone;
    public Material doneMat;
    public Material wrongMat;
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
            {
                button.gameObject.GetComponent<MeshRenderer>().material = wrongMat;
            }

        }
        if (i == 4)
            faceDone = true;
        else
            faceDone = false;
    }
}
