using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static MyLibrary;

public class AgentScript : MonoBehaviour
{
    public NavMeshAgent self;

    public float eaten = 0;

    public float en = 50;


    void Update(){
        Vector3 curDest = self.destination;
        Vector3 curPos = self.transform.position;
        curDest.y = curPos.y;


        if(curDest == curPos){
            en = NextDest(self, en);
        }


        if(eaten >= 2){
            Home(self);
        }
    
    }

    void OnCollisionEnter(Collision other){
        Debug.Log("Collide");
        if(other.gameObject.CompareTag ("Food")){
            Debug.Log("Food");
            eaten++;
           Destroy(other.gameObject);
        }
        
    }

}
