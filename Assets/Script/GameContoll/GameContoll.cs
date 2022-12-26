using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameContoll : MonoBehaviour
{

    public GameObject backpack;         //背包
    public GameObject playerInterface;  //遊戲中玩家狀態
    public GameObject weaponBackground; //升級武器背景
    public GameObject[] weaponList = new GameObject [6];    //六個武器欄位
    public TMP_Text[] itemText = new TMP_Text [3];
    //public TMP_Text item1,item2,item3;
    public Button[] buttonList = new Button [3];
    public bool gameIsPause;
    int currentItemNumber1 = 0;int currentItemNumber2 = 0;int currentItemNumber3 = 0;
    // Start is called before the first frame update

    void Awake(){
        for (int i=0;i<buttonList.Length;i++){
            buttonList[i] = GetComponent<Button>();
            itemText[i] = GetComponent<TMP_Text>();
        }
    }
    void Start()
    {
        gameIsPause = false;
        
        backpack = GameObject.Find("Backpack");
        playerInterface = GameObject.Find("PlayInterface");
        weaponBackground = GameObject.Find("WeaponBackground");
        weaponList = GameObject.FindGameObjectsWithTag("Sword");
        for (int i=1; i<=buttonList.Length; i++){
           buttonList[i-1] = GameObject.Find("ItemButton" + i.ToString()).GetComponent<Button>();
           buttonList[i-1].onClick.AddListener(delegate() {on_click_LV_UP(currentItemNumber1);});
           itemText[i-1]   = GameObject.Find("ItemText" + i.ToString()).GetComponent<TMP_Text>();
           
        }
        //btn1.onClick.AddListener(delegate() {on_click_LV_UP(currentItemNumber1);});
        //btn2.onClick.AddListener(delegate() {on_click_LV_UP(currentItemNumber2);});
        //btn3.onClick.AddListener(delegate() {on_click_LV_UP(currentItemNumber3);});
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

    public void on_click_LV_UP(int n){
        //current weapon active script and level up
        active_weapon_and_LV_UP(n);

        backpack.SetActive(false);
        playerInterface.SetActive(true);
        weaponBackground.SetActive(false);
        Time.timeScale = 1f;
        //print(n);
    }

    public void count(int n){
        //n++;
        print (n);

    }

    public void LV_UP(){
        
        currentItemNumber1 =  Random.Range(0,6);
        currentItemNumber2 =  Random.Range(0,6);
        currentItemNumber3 =  Random.Range(0,6);
        for (int i=0; i<itemText.Length;i++){
            itemText[i].text = "Sword " + (currentItemNumber1+1).ToString();
        }
        // item1.text = "Sword " + (currentItemNumber1+1).ToString();
        // item2.text = "Sword " + (currentItemNumber2+1).ToString();
        // item3.text = "Sword " + (currentItemNumber3+1).ToString();
        
        
        backpack.SetActive(true);
        playerInterface.SetActive(false);
        weaponBackground.SetActive(true); //要選定好武器了
        Time.timeScale = 0f;
    }

    private void active_weapon_and_LV_UP(int n){
        switch (n){
            case 0:
                weaponList[n].GetComponent<spawn_Sword1>().enabled = true;
                weaponList[n].GetComponent<spawn_Sword1>().level++;
                break;
            case 1:
                weaponList[n].GetComponent<spawn_Sword2>().enabled = true;
                weaponList[n].GetComponent<spawn_Sword2>().level++;
                break;
            case 2:
                weaponList[n].GetComponent<spawn_Sword3>().enabled = true;
                weaponList[n].GetComponent<spawn_Sword3>().level++;
                break;
            case 3:
                weaponList[n].GetComponent<spawn_Sword4>().enabled = true;
                weaponList[n].GetComponent<spawn_Sword4>().level++;
                break;
            case 4:
                weaponList[n].GetComponent<spawn_Sword5>().enabled = true;
                weaponList[n].GetComponent<spawn_Sword5>().level++;
                break;
            case 5:
                weaponList[n].GetComponent<spawn_Sword6>().enabled = true;
                weaponList[n].GetComponent<spawn_Sword6>().level++;
                break;
        }
        print ("Sword" + n.ToString() +"  active.");

    }
    
}
