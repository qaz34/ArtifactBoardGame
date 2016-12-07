﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
public class Player : MonoBehaviour
{
    public Material accessable, inacessable;
    public int MoveSpeed = 2;
    public GameObject map;
    public Location location;
    List<Location> m_map;
    GameManager gm;
    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        var _map = map.GetComponentsInChildren<Location>();
        m_map = _map.ToList();
        location = m_map[Random.Range(0, m_map.Count)];       
    }
    public void ColorMap()
    {
        foreach(Location loc in m_map)
        {
            loc.GetComponent<MeshRenderer>().material = inacessable;
            loc.accessable = false;
        }
        foreach(Location loc in location.connectedLands)
        {
            loc.GetComponent<MeshRenderer>().material = accessable;
            loc.accessable = true;
            foreach (Location conCon in loc.connectedLands)
            {
                conCon.GetComponent<MeshRenderer>().material = accessable;
                conCon.accessable = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = location.transform.position;
    }
}