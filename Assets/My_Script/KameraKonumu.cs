using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKonumu : MonoBehaviour
{
    int kamerapos;
    // Start is called before the first frame update
    public GameObject pos0;
    public GameObject pos1;
    public GameObject pos2;
    


    void Start()
    {
       
        kamerapos = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void KameraKonumuDegistir()
    {
        kamerapos++; if (kamerapos > 2) kamerapos = 0;






        switch (kamerapos)
        {
            case 0: transform.position = pos0.transform.position; transform.rotation = pos0.transform.rotation; break;
            case 1: transform.position = pos1.transform.position; transform.rotation = pos1.transform.rotation; break;
            case 2: transform.position = pos2.transform.position; transform.rotation = pos2.transform.rotation; break;

        }
    }
}
