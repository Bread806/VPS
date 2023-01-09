using UnityEngine;

[System.Serializable]
public class SwordDescribe : MonoBehaviour
{
    private int level;
    private string[] swordDescribe1 = new string [8];
    private string[] swordDescribe2 = new string [9];
    private string[] swordDescribe3 = new string [8];
    private string[] swordDescribe4 = new string [9];
    private string[] swordDescribe5 = new string [8];
    private string[] swordDescribe6 = new string [8];

    private static SwordDescribe instance;

    public SwordDescribe(){}

    public static SwordDescribe get_instance(){
        if (instance==null) instance = new SwordDescribe();
        return instance;
    }

    public void init_dict(){
        //S1
        swordDescribe1[0] = "Level : 1 \n A long-range sword fired in all directions, dealing damage to enemies.";
        for(int i=1; i<8; i++)
        {
            swordDescribe1[i] ="Level : " + (i+1).ToString() + "\n A long-range sword fired in all directions. Increases the damage and attack speed of each longsword.";
        }

        //S2
        swordDescribe2[0] = "level : 1 \n You will summon a Fuma Shuriken to fight around you.";
        for (int i=1;i<4;i++)
        swordDescribe2[i] = "level : " + (i+1).ToString() + " \n Fuma Shurikens fight around you and deal increased damage.";
        swordDescribe2[4] = "level : 5 \n Fuma Shuriken fight around you, and the summon duration increases.";
        swordDescribe2[5] = "level : 6 \n Fuma Shuriken fight around you, and the summon's cooldown is reduced.";
        swordDescribe2[6] = "level : 7 \n Fuma Shuriken fight around you, and can summon an additional Fuma Shuriken.";
        swordDescribe2[7] = "level : 8 \n Fuma Shuriken fight around you, and can summon an additional Fuma Shuriken.";
        swordDescribe2[8] = "level : 9 \n powerful Fuma Shuriken is coming right up.";

        //S3
        swordDescribe3[0] = "level : 1 \n The black hole will fight for you.";
        swordDescribe3[1] = "level : 2 \n The Black Hole will fight for you and deal increased damage.";
        swordDescribe3[2] = "level : 3 \n The black hole will fight for you and increase the attack range of the black hole.";
        swordDescribe3[3] = "level : 4 \n The Black Hole will fight for you and deal increased damage.";
        swordDescribe3[4] = "level : 5 \n The Black Hole will fight for you and deal increased damage.";
        swordDescribe3[5] = "level : 6 \n The black hole will fight for you and increase the attack range of the black hole.";
        swordDescribe3[6] = "level : 7 \n The black hole will be divided into two around you.";
        swordDescribe3[7] = "level : 8 \n The number of black holes will be increased to 4.";

        //S4
        swordDescribe4[0] = "level : 1 \n There will be spiked balls falling from the sky.";
        swordDescribe4[1] = "level : 2 \n There will be iron spike balls falling from the sky, and the cooldown of summoning will be shortened.";
        swordDescribe4[2] = "level : 3 \n Can additionally summon a group of Iron Spike Balls.";
        swordDescribe4[3] = "level : 4 \n Can additionally summon a Mini Spike Ball.";
        swordDescribe4[4] = "level : 5 \n Can additionally summon a group of Iron Spike Balls.";
        swordDescribe4[5] = "level : 6 \n There will be iron spike balls falling from the sky, and the cooldown of summoning will be shortened.";
        swordDescribe4[6] = "level : 7 \n There will be iron spike balls falling from the sky, and the cooldown of summoning will be shortened.";
        swordDescribe4[7] = "level : 8 \n Can additionally summon a Mini Spike Ball.";
        swordDescribe4[8] = "level : 9 \n disaster Spike Ball is coming right up.";

        //S5
        swordDescribe5[0] = "level : 1 \n There will be patrolling throwing knives fighting for you.";
        swordDescribe5[1] = "level : 2 \n There will be patrolling flying knives fighting for you, and the upper limit of summoning will be increased.";
        swordDescribe6[2] = "level : 3 \n There will be patrolling flying knives fighting for you, and the upper limit of summoning will be increased.";
        swordDescribe5[3] = "level : 4 \n There will be patrolling throwing knives fighting for you and increasing the damage dealt.";
        swordDescribe5[4] = "level : 5 \n There will be patrolling throwing knives fighting for you and increasing the damage dealt.";
        swordDescribe5[5] = "level : 6 \n There will be patrolling throwing knives fighting for you and increasing the damage dealt.";
        swordDescribe5[6] = "level : 7 \n There will be patrolling flying knives fighting for you, and the cooldown time of summoning will be shortened.";
        swordDescribe5[7] = "level : 8 \n There will be patrolling flying knives fighting for you, and the upper limit of summoning will be increased.";

        //S6
        swordDescribe6[0] = "level : 1 \n Throw a swift long sword in front of you to attack the enemy.";
        swordDescribe6[1] = "level : 2 \n Increase the number of longsword shots.";
        swordDescribe6[2] = "level : 3 \n Increase the number of longsword shots.";
        swordDescribe6[3] = "level : 4 \n Increase the number of longsword shots.";
        swordDescribe6[4] = "level : 5 \n Shortened longsword launch time.";
        swordDescribe6[5] = "level : 6 \n Shortened longsword launch time.";
        swordDescribe6[6] = "level : 7 \n Shortened longsword launch time.";
        swordDescribe6[7] = "level : 8 \n Shortened longsword launch time.";
        
    }


    public string get_sword_describe(int num, int level){ //bread
        if (level > 8 ) return "null";
        switch (num){
            case 0:
            return swordDescribe1[level];
            case 1:
            return swordDescribe2[level];
            case 2:
            return swordDescribe3[level];
            case 3:
            return swordDescribe4[level];
            case 4:
            return swordDescribe5[level];
            case 5:
            return swordDescribe6[level];
        }
        return "null";
    }


}
