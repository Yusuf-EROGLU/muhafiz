using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseAdamYarat : MonoBehaviour
{
    //bu kod kamerada çalışmaktadır.
    // deneme amaçlı yazılmıştır pasif durumdadır.
    public GameObject asker;
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           // Vector3 pos = Input.mousePosition;
           // pos.y = 1.0f;
            
            RaycastHit hit;
            
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,Mathf.Infinity))
            {
                
                    Instantiate(asker,hit.point, Quaternion.identity);
                   
;            }
        }
    }
}
