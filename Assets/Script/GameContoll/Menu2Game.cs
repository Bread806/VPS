using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Menu2Game : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioManager audioManager;
    private TMP_Text soundText;
    private int soundVolume;
    private bool isH2PPanelOpen;
    private GameObject H2PPanel;

    void Awake()
    {
        soundText = GetComponent<TMP_Text>();
    }
    void Start()
    {
        soundVolume = 3;
        isH2PPanelOpen = false;
        H2PPanel  = GameObject.Find("B_H2P");
        H2PPanel.SetActive(false);
        soundText = GameObject.Find("SoundText").GetComponent<TMP_Text>();
        set_volume_text(soundVolume);
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        audioManager.play_clip("menu");

    }

    public void Start2Game()
    {
        SceneManager.LoadScene ("Game");
    }

    public void QuitGame(){
        Application.Quit();

    }

    public void volume_up(){
        if (soundVolume >= 10) return;
        audioManager.volume_up("menu");
        soundVolume++;
        set_volume_text(soundVolume);
    }

    public void volume_down(){
        if (soundVolume <= 0) return;
        audioManager.volume_down("menu");
        soundVolume--;
        set_volume_text(soundVolume);
    }
    
    public void show_H2P(){
        if (isH2PPanelOpen){            // going to  close0
            H2PPanel.SetActive(false);
            isH2PPanelOpen = false;
        }
        else{                           //going to open
            H2PPanel.SetActive(true);
            isH2PPanelOpen = true;
        }
    }

    private void set_volume_text(int soundVolume){

        soundText.text =  "Volume\n" + soundVolume.ToString();

    }

    
// Update is called once per frame
    void Update()
    {

    }
}
