using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaikaSpawn : MonoBehaviour
{
    private GameMaster gameMaster;
    private EnnemisStateMachine ennemisStateMachine;

    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        ennemisStateMachine = GameObject.FindGameObjectWithTag("Ennemi").GetComponent<EnnemisStateMachine>();

        transform.position = gameMaster.LastCheckPointPos;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }*/

        if(ennemisStateMachine.currentState.name == "EnemiAttack")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
