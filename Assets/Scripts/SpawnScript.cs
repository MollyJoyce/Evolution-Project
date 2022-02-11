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

    public float foodAmount = 30;
    float crCount = MyLibrary.creatureAmount;
    //public static float creatureAmount = 10;




    public static void CreatureSpawn (UnityEngine.AI.NavMeshAgent agent, float pop, Transform par){

    for (int h = 0; h < pop; h++){
            UnityEngine.AI.NavMeshAgent curcre = Instantiate(agent);

            Edge(curcre, par);

        }
}


public void FoodSpawn(GameObject food, float amount, Transform par){

    for (int i = 0; i < amount; i++){
            GameObject curfood = Instantiate(food);

            Vector3 pos;

            pos.x = Random.Range(-11, 11);
            pos.y = .125f;
            pos.z = Random.Range(-11, 11);

            curfood.transform.position = pos;
           
            curfood.transform.SetParent(par);

            curfood.tag = "Food";
        }
}



    void Start(){
            FoodSpawn(nourishment, foodAmount, pointPar);

            CreatureSpawn(creature, crCount, crePar);  

    }

}

    
