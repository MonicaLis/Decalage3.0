﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnRoom1 : MonoBehaviour
{

    public Transform CubeRoom;
    public Transform Carpet;
    public Transform player;
    public Transform RoomMusic;

    bool musicOff = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 proximity = player.transform.position - transform.position;
        if (proximity.magnitude < 7f)
        {
            player.transform.position = new Vector3(218.38f, -39.02f, 221.6824f);
            GetComponent<MeshRenderer>().enabled = false;
            Carpet.GetComponent<BoxCollider>().enabled = true;
            int[] indexDoor = { 20, 21, 22, 30, 31, 32 };
            Transform Wall = CubeRoom.transform.GetChild(2);
            for (int i = 0; i < indexDoor.Length; i++)
            {
                Wall.transform.GetChild(indexDoor[i]).GetComponent<MeshRenderer>().enabled = true;
                Wall.transform.GetChild(indexDoor[i]).GetComponent<BoxCollider>().enabled = true;
            }

            for (int i=0; i < CubeRoom.childCount; i++)
            {
                CubeRoom.transform.GetChild(i).GetComponent<MovingBlocks>().enabled = true;
            }
            RoomMusic.GetComponent<AudioSource>().enabled = true;
            musicOff = true;
        }
        Debug.Log("Return proximity " + proximity.magnitude);

        if (RoomMusic.GetComponent<AudioSource>().volume < 0.8f && musicOff == true)
        {
            RoomMusic.GetComponent<AudioSource>().volume += Time.deltaTime * 0.2f;
            CubeRoom.GetComponent<AudioSource>().volume -= Time.deltaTime * 0.4f;
        }
        if (RoomMusic.GetComponent<AudioSource>().volume > 0.8f && musicOff == true)
        {
            CubeRoom.GetComponent<AudioSource>().enabled = false;
            musicOff = false;
        }
    }
}