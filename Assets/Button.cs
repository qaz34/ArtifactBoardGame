using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
    public State state;
    private State finalState;
    public bool correct;
    // Use this for initialization
    void Start()
    {
        state = (State)Random.Range(-1, 1);
        finalState = (State)Random.Range(-1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == finalState)
            correct = true;
        else
            correct = false;

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, (float)state / 10);
    }
}
public enum State
{
    Pressed = -1,
    Untouched = 0,
    Out = 1
}