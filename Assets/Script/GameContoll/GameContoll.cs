using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoll : MonoBehaviour
{
    public GameObject backpack;
    public GameObject playerInterface;
    //public spawn_
    public bool gameIsPause;
    // Start is called before the first frame update
    void Start()
    {
        gameIsPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (gameIsPause)
            {
                resume();
            }
            else
            {
                pause();
            }

            if (Input.GetKeyUp(KeyCode.T))
            {
                //player.

            }


        }

        void pause()
        {
            backpack.SetActive(true);
            playerInterface.SetActive(false);
            Time.timeScale = 0f;
            gameIsPause = true;
        }
        void resume()
        {
            backpack.SetActive(false);
            playerInterface.SetActive(true);
            Time.timeScale = 1f;
            gameIsPause = false;
        }
    }
}
