using UnityEngine;

[System.Serializable]
public class SwordDescribe : MonoBehaviour
{
    private int level;
    private string[] swordDescribe1 = new string [8];
    private string[] swordDescribe2 = new string [8];
    private string[] swordDescribe3 = new string [8];
    private string[] swordDescribe4 = new string [8];
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
        swordDescribe1[0] = "A long-range sword fired in all directions, dealing damage to enemies.";
        for(int i=1; i<8; i++)
        {
            swordDescribe1[i] ="A long-range sword fired in all directions. Increases the damage and attack speed of each longsword.";
        }

        //S2
        swordDescribe2[0] = "You will summon a Fuma Shuriken to fight around you.";
        for (int i=1;i<4;i++)
        swordDescribe2[i] = "Fuma Shurikens fight around you and deal increased damage.";
        swordDescribe2[4] = "Fuma Shuriken fight around you, and the summon duration increases.";
        swordDescribe2[5] = "Fuma Shuriken fight around you, and the summon's cooldown is reduced.";
        swordDescribe2[6] = "Fuma Shuriken fight around you, and can summon an additional Fuma Shuriken.";
        swordDescribe2[7] = "Fuma Shuriken fight around you, and can summon an additional Fuma Shuriken.";

        //S3
        swordDescribe3[0] = "The black hole will fight for you.";
        swordDescribe3[1] = "The Black Hole will fight for you and deal increased damage.";
        swordDescribe3[2] = "The black hole will fight for you and increase the attack range of the black hole.";
        swordDescribe3[3] = "The Black Hole will fight for you and deal increased damage.";
        swordDescribe3[4] = "The Black Hole will fight for you and deal increased damage.";
        swordDescribe3[5] = "The black hole will fight for you and increase the attack range of the black hole.";
        swordDescribe3[6] = "The black hole will be divided into two around you.";
        swordDescribe3[7] = "The number of black holes will be increased to 4.";

        //S4
        swordDescribe4[0] = "There will be spiked balls falling from the sky.";
        swordDescribe4[1] = "There will be iron spike balls falling from the sky, and the cooldown of summoning will be shortened.";
        swordDescribe4[2] = "Can additionally summon a group of Iron Spike Balls.";
        swordDescribe4[3] = "Can additionally summon a Mini Spike Ball.";
        swordDescribe4[4] = "Can additionally summon a group of Iron Spike Balls.";
        swordDescribe4[5] = "There will be iron spike balls falling from the sky, and the cooldown of summoning will be shortened.";
        swordDescribe4[6] = "There will be iron spike balls falling from the sky, and the cooldown of summoning will be shortened.";
        swordDescribe4[7] = "Can additionally summon a Mini Spike Ball.";

        //S5
        swordDescribe5[0] = "There will be patrolling throwing knives fighting for you.";
        swordDescribe5[1] = "There will be patrolling flying knives fighting for you, and the upper limit of summoning will be increased.";
        swordDescribe6[2] = "There will be patrolling flying knives fighting for you, and the upper limit of summoning will be increased.";
        swordDescribe5[3] = "There will be patrolling throwing knives fighting for you and increasing the damage dealt.";
        swordDescribe5[4] = "There will be patrolling throwing knives fighting for you and increasing the damage dealt.";
        swordDescribe5[5] = "There will be patrolling throwing knives fighting for you and increasing the damage dealt.";
        swordDescribe5[6] = "There will be patrolling flying knives fighting for you, and the cooldown time of summoning will be shortened.";
        swordDescribe5[7] = "There will be patrolling flying knives fighting for you, and the upper limit of summoning will be increased.";

        //S6
        swordDescribe6[0] = "Throw a swift long sword in front of you to attack the enemy.";
        swordDescribe6[1] = "Increase the number of longsword shots.";
        swordDescribe6[2] = "Increase the number of longsword shots.";
        swordDescribe6[3] = "Increase the number of longsword shots.";
        swordDescribe6[4] = "Shortened longsword launch time.";
        swordDescribe6[5] = "Shortened longsword launch time.";
        swordDescribe6[6] = "Shortened longsword launch time.";
        swordDescribe6[7] = "Shortened longsword launch time.";
        
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
