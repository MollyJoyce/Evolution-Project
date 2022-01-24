using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static MyLibrary;

public class SpawnScript : MonoBehaviour{

    float foox;
    float fooz;

    Vector3 pos;

    public Transform pointPar;
    public Transform crePar;

    public GameObject nourishment;
    public NavMeshAgent creature;

    public float foodAmount = 50;
    public float creatureAmount = 10;




    public void CreatureSpawn (UnityEngine.AI.NavMeshAgent agent, float pop){

    for (int h = 0; h < pop; h++){
            UnityEngine.AI.NavMeshAgent curcre = Instantiate(agent);

            float edge;
            float edgepos;

            edge = Random.Range(1,5);
            edgepos = Random.Range(-13, 13);

            if(edge == 1){
                pos = new Vector3(edgepos, 0f, 13f);
            }else if(edge == 2){
                pos = new Vector3(13f, 0f, edgepos);
            }else if(edge == 3){
                pos = new Vector3(edgepos, 0f, -13f);
            }else if(edge == 4){
                pos = new Vector3(-13f, 0f, edgepos);
            }


            curcre.transform.position = pos;
           
            curcre.transform.SetParent(crePar);
        }
}


public void FoodSpawn(GameObject food, float amount){

    for (int i = 0; i < amount; i++){
            GameObject curfood = Instantiate(food);

            Vector3 pos;

            pos.x = Random.Range(-13, 13);
            pos.y = .125f;
            pos.z = Random.Range(-13, 13);

            curfood.transform.position = pos;
           
            curfood.transform.SetParent(pointPar);

            curfood.tag = "Food";
        }
}



    void Start(){
            FoodSpawn(nourishment, foodAmount);

            CreatureSpawn(creature, creatureAmount);  

    }

}

    
