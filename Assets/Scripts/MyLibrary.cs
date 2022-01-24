using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Mathf;
using System.Linq;

public class MyLibrary{

    //Choose Next Random Destination

     public static float NextDest (UnityEngine.AI.NavMeshAgent agent, float energy){
         if(energy > 0){

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

        energy = energy - 10;

         }

        Debug.Log(energy);

        return energy;
         

       

        

    }


    //Check if agent has reached destination

    public static void DestCheck (UnityEngine.AI.NavMeshAgent agent, Vector3 dest, float energy){
        if(agent.transform.position == dest){
            MyLibrary.NextDest(agent, energy);

            
        }

        
    }


    //Send Home

    public static void Home (UnityEngine.AI.NavMeshAgent agent){

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


    }


    //Use Energy

    public void EnegyUse


}
