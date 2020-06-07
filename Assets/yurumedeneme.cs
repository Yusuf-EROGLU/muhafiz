using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class yurumedeneme : MonoBehaviour
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
       
      

        
        if (HedefSecme.zombilerinHedef != null)
        {
            agent.SetDestination(HedefSecme.zombilerinHedef.transform.position);
            Debug.Log("asker hedef atandı");
        }
    }
}
