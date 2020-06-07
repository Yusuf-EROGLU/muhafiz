using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlkTasıma : MonoBehaviour
{
    //bu kod kulelerde çalışmaktadır.

    public RaycastHit hit;
    private bool yerlesti; 
    Vector3 yeniyer;
    //tasınırken rotasyon değistirmesin diye yazdım ama quaternion kullandım daha sonra
    //Vector3 sabitrotasyon;
    private void Awake()
    {
        yerlesti = false;
        //sabitrotasyon = new Vector3(0f,0f,0f);
    }


    private void OnMouseDrag()
    {
        Debug.Log("Kaleyi tuttun");
        if (!yerlesti) { 
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                
                    if (hit.collider.CompareTag("Ortam"))
                    {
                        yeniyer = hit.point;
                        yeniyer.y = hit.point.y - 3f;
                        transform.position = yeniyer;
                                     
                       

                        transform.rotation = Quaternion.identity;
                        //transform.rotation. = sabitrotasyon;

                    }
                
            }
        }
    }

    private void OnMouseUp()
    {
        yerlesti = true;
    }


}
