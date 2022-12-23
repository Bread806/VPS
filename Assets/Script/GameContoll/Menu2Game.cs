using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu2Game : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {

    }

    public void Start2Game()
    {
        SceneManager.LoadScene ("Game");
    }

    public void QuitGame(){
        Application.Quit();

    }

// Update is called once per frame
    void Update()
    {

    }
}
