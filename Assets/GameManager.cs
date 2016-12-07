using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class GameManager : MonoBehaviour
{
    public List<Player> players;
    public Player currentPlayer;
    int player;
    // Use this for initialization
    void Start()
    {
        currentPlayer = players[player];
    }

    // Update is called once per frame
    void Update()
    {
        currentPlayer.ColorMap();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log("raycastHit");
                if (hit.transform.GetComponent<Location>() != null)
                    if (hit.transform.GetComponent<Location>().accessable)
                    {
                        currentPlayer.location = hit.transform.GetComponent<Location>();
                        player = (player + 1) % players.Count;
                        currentPlayer = players[player];
                    }
            }
        }
    }
}
