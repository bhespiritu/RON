using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Master : MonoBehaviour
{
    public GameObject elevator;
    private Elevator_Master eleCtrl;
    private Elevator_Master.eState mode;
    public int eBonus;
    private List<int> costs;
    private Dictionary<int, GameObject> eMap;
    private int credits, cMin, eCredSum;
    private List<GameObject> enemies;
    public List<GameObject> catalogue;
    public GameObject miniBoss;
    public int AddCred = 1;
    public Vector3[] spawnpoints;
    public GameObject player;
    private bool init;
    private float crAcc;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.playerInstance.gameObject;
        eleCtrl = elevator.GetComponent<Elevator_Master>(); 
        Elevator_Master.sChg += ElevatorSignal;
        mode = eleCtrl.st;
        init = true;
        crAcc = 0f;
        enemies = new List<GameObject>();
        costs = new List<int>();
        eMap = new Dictionary<int, GameObject>();
        eCredSum = 0;
        //Debug.Log("Before catalogue initialization.");
        /*for(int i = 0; i < catalogue.Count; i++){
            GameObject enemy = catalogue[i];
            costs.Add(enemy.GetComponent<EnemyInfo>().difficulty);
            eMap.Add(enemy.GetComponent<EnemyInfo>().difficulty, enemy);
        } */
        /*foreach(GameObject enemy in catalogue){
            //costs.Add(enemy.GetComponent<EnemyInfo>().difficulty);
            //eMap.Add(enemy.GetComponent<EnemyInfo>().difficulty, enemy);
        }*/
    }

    void init2(){
        cMin = catalogue[0].GetComponent<EnemyInfo>().difficulty;
        foreach(GameObject enemy in catalogue){
            int cTemp = enemy.GetComponent<EnemyInfo>().difficulty;
            if(enemy == null){Debug.Log("Null prefab init2");}
            EnemyInfo temp = enemy.GetComponent<EnemyInfo>();
            if(temp == null){Debug.Log("Null info init2");}else{/*Debug.Log("Difficulty is " + temp.difficulty);*/}
            costs.Add(enemy.GetComponent<EnemyInfo>().difficulty);
            if(cTemp < cMin){cMin = cTemp;}
            eMap.Add(enemy.GetComponent<EnemyInfo>().difficulty, enemy);
        }
        init = false;
        diagnostic();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("starting spawn update...");
        if(init){
            init2();
            init = false;
        }
        //Debug.Log("Past init2...");

        crAcc += (GameTimer.time/30f+1)*Time.deltaTime*(1-Mathf.Min(eCredSum/GameTimer.time, 1));
        if(mode == Elevator_Master.eState.Event){
            crAcc += eBonus * Time.deltaTime*(GameTimer.time/30f+1);
        }
        
        if(crAcc > cMin * 3){
            int temp = Mathf.FloorToInt(crAcc);
            credits += temp;
            crAcc -= temp;

            if(mode == Elevator_Master.eState.Finished){
                crAcc = GameTimer.time/30f;
            }else{
                credits = doSpawns(credits);
            }

        }
        //int timeScl = Mathf.FloorToInt(GameTimer.time/30);
        
    }

    int doSpawns(int creds){
        //Debug.Log("Attempting to spawn, credits = " + credits);
        int remaining = creds;
        int eTypes = catalogue.Count;
        int eCost = creds + 1;
        int ct = 0;
        int indCat = 0;
        bool skip = false;
        Vector3 sPos = spawnPosRand();
        while(eCost>creds && !skip){
            skip = UnityEngine.Random.Range(0f, 1f) < .01f ? true : false;
            indCat = UnityEngine.Random.Range(0, eTypes);
            eCost = catalogue[indCat].GetComponent<EnemyInfo>().difficulty;
        }
        if(skip){remaining = Mathf.Min(Mathf.FloorToInt(GameTimer.time), remaining);return remaining;}

        ct = creds/eCost;
        ct = Mathf.FloorToInt(UnityEngine.Random.Range(0f,Mathf.Min(ct,4)));
        for(int i = 0; i < ct; i ++){
            GameObject nEnemy = Instantiate(catalogue[indCat], sPos, Quaternion.identity);
            enemies.Add(nEnemy);
            eCredSum += catalogue[indCat].GetComponent<EnemyInfo>().difficulty;
            //credits -= catalogue[indCat].GetComponent<EnemyInfo>().difficulty; //Don't need this, updating the credits value in Update
            remaining -= catalogue[indCat].GetComponent<EnemyInfo>().difficulty;
        }

        remaining = Mathf.Min(Mathf.FloorToInt(GameTimer.time), remaining);

        return remaining;
    }

    private Vector3 spawnPosRand(){//Method to find a spawn location
        int i;
        Vector3 sLoc;
        do{
            i = UnityEngine.Random.Range(0, spawnpoints.Length);
            sLoc = spawnpoints[i];
        }while(Vector3.Distance(sLoc, player.transform.position)< 10f);
        
        return sLoc;
    }

    public void ElevatorSignal(){
        mode = eleCtrl.st;
        //Debug.Log("Spawner heard that EState changed");
    }

    GameObject SpawnSpecific(GameObject toSpawn){ //method called by other objects if they want to spawn things

        Vector3 sPos = new Vector3(0f,0f,0f);
        GameObject nEnemy = Instantiate(toSpawn, sPos, Quaternion.identity);
        enemies.Add(nEnemy);
        credits -= AddCred;
        return nEnemy;
    }

    public void SpawnMiniboss()
    {
        var boss = SpawnSpecific(miniBoss);
        boss.transform.position = transform.position + Vector3.up * 5;
    }

    void diagnostic(){
        //Debug.Log("catalogue length is " + catalogue.Count + ", eMap length is " + eMap.Count + ".");
    }

    public void kill(GameObject enemy){
        enemies.Remove(enemy);
        eCredSum -= enemy.GetComponent<EnemyInfo>().difficulty;

    }
}
