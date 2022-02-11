using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static MyLibrary;
using static UnityEngine.Mathf;



public class AgentScript : MonoBehaviour
{
    public NavMeshAgent self;

    public Transform crePar;

    public float eaten = 0;
    public float en = 50;
    public float enUse = 1;
    public float total = MyLibrary.creatureAmount + 1;

    public bool thisDone = false;
    public bool Fin = false;
    public bool home = false;
    public bool reachHome = false;
    public bool alive;

    Vector3 oldPos;
    public Vector3 pos;
    public float edge;
            public float edgepos;

    void Start(){
        oldPos = self.transform.position;
            

           
           pos.x = 0f;
           pos.y = 0f;
           pos.z = 0f;

            edge = Random.Range(1f,5f);
            edgepos = Random.Range(-13f, 13f);

            if(edge > 4){
                pos.x = edgepos;
                pos.z = 13f;
            }else if(edge > 3){
                pos.x = 13f;
                pos.z = edgepos;
            }else if(edge > 2){
                pos.x = edgepos;
                pos.z = -13f;
            }else if(edge > 1){
                pos.x = -13f;
                pos.z = edgepos;
            }

            pos.y = 0;


            self.transform.position = pos;
    }


    void Update(){

        Vector3 selfd = self.destination;
        Vector3 posRN = self.transform.position;
        selfd.y = posRN.y;
        

        if(Abs(selfd.x) == 13 || Abs(selfd.z) == 13){
            home = true;
            if(selfd == posRN){
                reachHome = true;
            }

        }

        Fin = allDone(MyLibrary.done, total);

        if (Fin == false){
        Vector3 curDest = self.destination;
        Vector3 curPos = self.transform.position;
        curDest.y = curPos.y;

        float diff = Vector3.Distance(oldPos, curPos);

        en -= (enUse*diff);
        oldPos = curPos;
        Debug.Log(en);

        if(en > 0){


        if(curDest == curPos){
           NextDest(self);
        }


        if(eaten >= 2){
            Home(self);
        }

        } else if(thisDone == false){
            thisDone = true;
            MyLibrary.done++;
        }

        if(home == true && self.transform.position == selfd && thisDone == false){
            thisDone = true;
            MyLibrary.done++;
        }
     

        }else if(Fin == true){
          alive = Survive(self, reachHome, eaten);

          if(alive == false){
              Destroy(self);

          } else if(eaten > 2){
              Birth(self, crePar);
          } else{

          }
            
        }
    
    }

    void OnCollisionEnter(Collision other){

        if(other.gameObject.CompareTag ("Food")){

            eaten++;
           Destroy(other.gameObject);
        } else if(other.gameObject.CompareTag ("Creature")){
            NextDest(self);
        }
        
    }

}
