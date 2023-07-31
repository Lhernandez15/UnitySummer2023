using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGate : MonoBehaviour
{
    public GameObject messageText;
    public GameObject cutAwayCamera;
    public bool GameOver = false;


    private void Update()
    {
        if (GameOver)
        {
            if (Input.GetKeyUp(KeyCode.Return)) 
            {
                //Restart game, gg, see ya
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        messageText.GetComponent<TMP_Text>().text = "You win!! \n Press Enter to play Again";
        messageText.SetActive(true);
        if (other.gameObject.tag == "capsule")
        {
            other.GetComponent<CharacterController>().enabled = false;
            StartCoroutine(ChangeCamera());
        }
    }

    IEnumerator ChangeCamera()
    {
        yield return new WaitForSeconds(2.0f);
        GameOver = true;
        GameObject.Find("MainCamera").SetActive(false);
        cutAwayCamera.SetActive(false);
    }
}
