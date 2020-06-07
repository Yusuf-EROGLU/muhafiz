using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskerYarat : MonoBehaviour
{

    bool platformbos;


    private void Start()
    {
        platformbos = true;
    }
    public GameObject asker2referansı;
    public GameObject asker3referansı;
    public GameObject asker4referansı;
    public GameObject asker1referansı;
    //  public Collider kontrolkupu;

    public void AskeriYarat(int askerType)
    {

        if (!platformbos) return;
        Vector3 ilkKonum = transform.position;
        ilkKonum.y = 5.0f;
        if(askerType ==1 && KaleYasam.kaleHazine.Getpara() >= 100) { Instantiate(asker1referansı, transform.position, transform.rotation); KaleYasam.kaleHazine.Harca(100); }
        if (askerType == 2 && KaleYasam.kaleHazine.Getpara() >= 200) { Instantiate(asker2referansı, transform.position, transform.rotation); KaleYasam.kaleHazine.Harca(200); }
        if (askerType == 3 && KaleYasam.kaleHazine.Getpara() >= 300) { Instantiate(asker3referansı, transform.position, transform.rotation); KaleYasam.kaleHazine.Harca(300); }
        if (askerType == 4 && KaleYasam.kaleHazine.Getpara() >= 400) { Instantiate(asker4referansı, transform.position, transform.rotation); KaleYasam.kaleHazine.Harca(400); }


        /*
        switch (askerType) { 
            case 1:Instantiate(asker1referansı, transform.position, transform.rotation); KaleYasam.kaleHazine.Harca(100);  break;
            case 2:Instantiate(asker2referansı, transform.position, transform.rotation); KaleYasam.kaleHazine.Harca(200); break;
            case 3:Instantiate(asker3referansı, transform.position, transform.rotation); KaleYasam.kaleHazine.Harca(300); break;
            case 4:Instantiate(asker4referansı, transform.position, transform.rotation); KaleYasam.kaleHazine.Harca(400); break;
        }*/
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
