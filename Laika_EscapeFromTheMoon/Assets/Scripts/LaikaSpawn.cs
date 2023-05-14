using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaikaSpawn : MonoBehaviour
{
    private GameMaster gameMaster;
    private EnnemisStateMachine ennemisStateMachine;
    public float TimeBeforeRestart;

    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        ennemisStateMachine = GameObject.FindGameObjectWithTag("Ennemi").GetComponent<EnnemisStateMachine>();

        transform.position = gameMaster.LastCheckPointPos;
    }

   

    public IEnumerator WaitToReStart()
    {
        yield return new WaitForSeconds(TimeBeforeRestart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {

        if(ennemisStateMachine.currentState.name == "EnemiAttack")
        {
            StartCoroutine(WaitToReStart());
        }
        
    }
}
