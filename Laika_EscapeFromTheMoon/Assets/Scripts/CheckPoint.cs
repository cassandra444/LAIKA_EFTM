using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameMaster gameMaster;

    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Laika"))
        {
            gameMaster.LastCheckPointPos = transform.position;
        }
    }
}
