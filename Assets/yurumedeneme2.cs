using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class yurumedeneme2 : MonoBehaviour
{
    NavMeshAgent agent;
  //  GameObject hedef;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       
      

        if (HedefSecme.team1inHedef != null)
        {
            agent.SetDestination(HedefSecme.team1inHedef.transform.position);
            Debug.Log("zombi hedef atandı");
        }
        
        
    }
}
