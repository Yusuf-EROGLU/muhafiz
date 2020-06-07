using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuleYarat : MonoBehaviour
{
    bool platformbos;

    public GameObject kule2referansı;
  
    public GameObject kule1referansı;

    private void Start()
    {
        platformbos = true;
    }

    public void KuleyiYarat(int kuleType)
    {
        if (!platformbos) return;
        Vector3 ilkKonum = transform.position;
        ilkKonum.y = ilkKonum.y+ 0.2f;
        if(kuleType == 0)Instantiate(kule1referansı, ilkKonum, transform.rotation);
        else if(kuleType == 1) { Instantiate(kule2referansı, ilkKonum, transform.rotation); }


    }

    void OnTriggerEnter(Collider other)
    {
        platformbos = false;
    }
    private void OnTriggerExit(Collider other)
    {
        platformbos = true;
    }
}
