using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Mathf;
using System.Linq;

//comment

public class MyLibrary{

    public static float creatureAmount = 10;

    public static float done = 0;


    //Set position as edge

    public static void Edge(NavMeshAgent agent, Transform par){

        Vector3 pos;
        float edge;
        float edgepos;

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


            agent.transform.position = pos;

            agent.transform.SetParent(par);
    }


    //Choose Next Random Destination

     public static void NextDest (UnityEngine.AI.NavMeshAgent agent){

         Vector3 lastPos = agent.transform.position;
        

        Vector3 d;
        Vector3 agentpos = agent.transform.position;

        if(agentpos.x < -8){
            d.x = agentpos.x + 5;
        } else if( agentpos.x > 8){
            d.x = agentpos.x - 5;
        } else {
           d.x = Random.Range(agentpos.x - 5, agentpos.x + 5); 
        }

        if(agentpos.z < -8){
            d.z = agentpos.z + 5;
        } else if( agentpos.z > 8){
            d.z = agentpos.z - 5;
        } else {
           d.z = Random.Range(agentpos.z - 5, agentpos.z + 5); 
        }
        
        d.y = agentpos.y;
       
        agent.SetDestination(d);

        
        ;


         

        

        //https://docs.unity3d.com/ScriptReference/Vector3.Distance.html
         
         

       

        

    }


    //Check if agent has reached destination

    public static void DestCheck (UnityEngine.AI.NavMeshAgent agent, Vector3 dest){
        if(agent.transform.position == dest){
            MyLibrary.NextDest(agent);

            
        }

        
    }


    //Send Home

    public static Vector3 Home (UnityEngine.AI.NavMeshAgent agent){

        Vector3 pos = agent.transform.position;

        List<float> sides = new List<float>();

        Vector3 dest = agent.transform.position;

        float distop = Mathf.Abs(13 - pos.x);
        sides.Add(distop);
        float disbot = Mathf.Abs(-13 - pos.x);
        sides.Add(disbot);
        float disleft = Mathf.Abs(13 - pos.z);
        sides.Add(disleft);
        float disright = Mathf.Abs(-13 - pos.z);
        sides.Add(disright);

        float closest = sides.Min();

        if(closest == distop){
            dest.x = 13;
        } else if(closest == disbot){
            dest.x = -13;
        }else if(closest == disleft){
            dest.z = -13;
        }else if(closest == disright){
            dest.z = 13;
        }

        agent.SetDestination(dest);

        return dest;


    }

    //check if all creaturs are done

    public static bool allDone(float amDone, float amAll){

        if(amDone == amAll){
            return true;
        } else{
            return false;
        }
    }

    //check if alive

    public static bool Survive (NavMeshAgent agent, bool home, float food){
        if(home = true && food >= 1){
            return true;
        } else {
            return false;
        }
            
    }

    public static void Birth (NavMeshAgent agent, Transform parent){

    }



    

        

       
    

     //https://docs.unity3d.com/ScriptReference/Physics.SphereCast.html


}


//comment