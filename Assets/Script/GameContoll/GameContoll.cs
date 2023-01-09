using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameContoll : MonoBehaviour
{

    private GameObject backpack;         //背包
    private float currentTime;           //遊戲時間
    private GameObject player;
    private GameObject playerInterface;  //遊戲中玩家狀態
    private GameObject weaponBackground; //升級武器背景
    private GameObject gameOver;
    private GameObject buttonBackround;
    private GameObject[] weaponList = new GameObject[6];    //六個武器欄位
    private SwordDescribe swordDescribe = new SwordDescribe(); //武器描述
    private TMP_Text[] itemText = new TMP_Text[3];
    private TMP_Text soundText;
    private TMP_Text killResult;
    public Sprite[] weaponImageList = new Sprite[6];
    private Image[] LVUPImageList = new Image[3];
    private Button[] buttonList = new Button[3];
    private bool gameIsPause;
    private int[] currentItemNumber = new int[3];
    private int soundVolume;
    private AudioManager audioManager;
    // Start is called before the first frame update

    void Awake()
    {
        //string = interfacearr[weaponList[i].level]
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i] = GetComponent<Button>();
            itemText[i] = GetComponent<TMP_Text>();
        }
        for (int i=0; i<LVUPImageList.Length; i++)
            LVUPImageList[i] = GetComponent<Image>();
        soundText = GetComponent<TMP_Text>();
        killResult= GetComponent<TMP_Text>();
    }
    void Start()
    {
        Time.timeScale = 1f;
        // init variable
  
        init_gameobj();
        init_button_listener();

        // init hierarchy
        init_hierarchy();

        gameIsPause = false;
        currentTime = 0f;
        audioManager.play_clip("BGM");
        soundVolume = 3;
        swordDescribe.init_dict();
        soundText.text = "Volume\n" + soundVolume.ToString();
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
        }

        currentTime += Time.deltaTime;
    }

    public void pause()
    {
        backpack.SetActive(true);
        playerInterface.SetActive(false);
        buttonBackround.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
        //audioManager.lower_volume("BGM");
    }
    public void resume()
    {
        backpack.SetActive(false);
        playerInterface.SetActive(true);
        buttonBackround.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
        //audioManager.normal_volume("BGM");
    }

    public void volume_up()
    {
        if(soundVolume == 10) return ;
        audioManager.volume_up("BGM");
        soundVolume++;
        soundText.text = "Volume\n" + soundVolume.ToString();
    }

    public void volume_down()
    {
        if(soundVolume == 0) return ;
        audioManager.volume_down("BGM");
        soundVolume--;
        soundText.text = "Volume\n" + soundVolume.ToString();
    }

    public void on_click_LV_UP(int n)
    {
        //current weapon active script and level up
        active_weapon_and_LV_UP(n);

        backpack.SetActive(false);
        playerInterface.SetActive(true);
        weaponBackground.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LV_UP()
    {   
        
        audioManager.play_clip("LVUP");
        for (int i = 0; i < itemText.Length; i++)
        {
            currentItemNumber[i] = Random.Range(0, 6);
            int currentWeaponLevel = get_sword_level(currentItemNumber[i]);
            LVUPImageList[i].sprite = weaponImageList[currentItemNumber[i]];
            itemText[i].text = swordDescribe.get_sword_describe(currentItemNumber[i], currentWeaponLevel);
        }

        backpack.SetActive(true);
        playerInterface.SetActive(false);
        weaponBackground.SetActive(true); //要選定好武器了
        buttonBackround.SetActive(false);
        Time.timeScale = 0f;
    }

    public float current_time()
    {
        return currentTime;
    }

    private void init_gameobj()
    {
        backpack = GameObject.Find("Backpack");
        player   = GameObject.Find("player");
        playerInterface = GameObject.Find("PlayInterface");
        weaponBackground = GameObject.Find("WeaponBackground");
        //weaponList = GameObject.FindGameObjectsWithTag("Sword");
        weaponList[0] = GameObject.Find("spawn_Sword1");
        weaponList[1] = GameObject.Find("spawn_Sword2");
        weaponList[2] = GameObject.Find("spawn_Sword3");
        weaponList[3] = GameObject.Find("spawn_Sword4");
        weaponList[4] = GameObject.Find("spawn_Sword5");
        weaponList[5] = GameObject.Find("spawn_Sword6");
        buttonBackround = GameObject.Find("ButtonBackground");
        killResult = GameObject.Find("KillResult").GetComponent<TMP_Text>();
        gameOver = GameObject.Find("Gameover");
        soundText = GameObject.Find("SoundText").GetComponent<TMP_Text>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        for (int i = 1; i <= buttonList.Length; i++)
        {
            currentItemNumber[i - 1] = 0;
            buttonList[i - 1] = GameObject.Find("ItemButton" + i.ToString()).GetComponent<Button>();
            itemText[i - 1] = GameObject.Find("ItemText" + i.ToString()).GetComponent<TMP_Text>();
            LVUPImageList[i - 1] = GameObject.Find("Item" + i.ToString()).GetComponent<Image>();
            LVUPImageList[i - 1].sprite = Resources.Load<Sprite>("Assets/Resources/This/S1.png");
        }
        for (int i=1; i<=weaponImageList.Length; i++){
            weaponImageList[i - 1] = Resources.Load<Sprite>("This/S" + i.ToString());
            //print ("Assets/Resources/This/S" + i.ToString() + ".png");
        }
        
    }

    private void init_button_listener()
    {
        buttonList[0].onClick.AddListener(delegate () { on_click_LV_UP(currentItemNumber[0]); });
        buttonList[1].onClick.AddListener(delegate () { on_click_LV_UP(currentItemNumber[1]); });
        buttonList[2].onClick.AddListener(delegate () { on_click_LV_UP(currentItemNumber[2]); });
    }

    private void init_hierarchy()
    {
        backpack.SetActive(false); 
        weaponBackground.SetActive(false);
        buttonBackround.SetActive(false);
        gameOver.SetActive(false);
    }

    public void end_game(){
        gameOver.SetActive(true);
        killResult.text = "You kill : " + player.GetComponent<PlayerState>().get_current_kill().ToString() + " enemies.";
        Time.timeScale = 0f;
        gameIsPause = true;
    }

    public void reload_game(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print ("reset done.");
        gameIsPause = false;
        //ceneManager.LoadScene ("Game");
    }

    public void back_to_menu(){
        SceneManager.LoadScene ("StartMenu");
    }

    private void active_weapon_and_LV_UP(int n)
    {
        switch (n)
        {
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
        print("Sword" + n.ToString() + "  LV up.");
    }

    private int get_sword_level(int n){
        switch (n)
        {
            case 0:
                return weaponList[n].GetComponent<spawn_Sword1>().level;
            case 1:
                return weaponList[n].GetComponent<spawn_Sword2>().level;
            case 2:
                return weaponList[n].GetComponent<spawn_Sword3>().level;
            case 3:
                return weaponList[n].GetComponent<spawn_Sword4>().level;
            case 4:
                return weaponList[n].GetComponent<spawn_Sword5>().level;
            case 5:
                return weaponList[n].GetComponent<spawn_Sword6>().level;
        }
        return 0;
    }

}
