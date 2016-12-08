using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class GameManager : MonoBehaviour
{
    public List<Player> players;
    public Player currentPlayer;
    public Material playerTurn;
    Material playerMat;
    int player;
    // Use this for initialization
    void Start()
    {
        currentPlayer = players[player];
        playerMat = currentPlayer.GetComponent<MeshRenderer>().material;
        foreach(Player Plr in players)
        {
            Plr.GetComponent<MeshRenderer>().material = playerTurn;
        }
        currentPlayer.GetComponent<MeshRenderer>().material = playerMat;
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
                        currentPlayer.GetComponent<MeshRenderer>().material = playerTurn;
                        currentPlayer = players[player];
                        currentPlayer.GetComponent<MeshRenderer>().material = playerMat;
                    }
            }
        }
    }
}
