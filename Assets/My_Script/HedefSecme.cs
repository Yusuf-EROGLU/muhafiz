using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedefSecme : MonoBehaviour
{
    //HedefSecici içersinde çalışacak
    //Alandaki gameObjectleri Team1 veya Team2 nin hedefi olarak atayacak
    //bu script içinde her kale hedef seçmek için Team#hedef şeklinde static nesne olusturuyor
    //eger static nesne bos ise hedef atanıyor dolu ise can karsılastırması yapılıyor canı dusuk olan hedef atanıyor.
    //

    public static GameObject team1inHedef;
    public static GameObject team2ninHedef;
    public static GameObject zombilerinHedef;
    public GameObject kale1;
    void Start()
    {
        //  team1inHedef = GameObject.Find("Zombie");
    }


    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Zombie"))
        {
            //Debug.Log("zombi var  !!!");
            // eşittir null olması lazım
            if (team1inHedef == null)
            {
                team1inHedef = other.gameObject;
                //  Debug.Log("zombi hedef");
            }
            else if (team1inHedef.CompareTag("Team1Kale") && other.CompareTag("Team1Asker"))
            {
                team1inHedef = other.gameObject;
            }
            else if (team1inHedef.CompareTag("Zombie") && other.CompareTag("Zombie"))
            {
                
                //if (team1inHedef.GetComponent<ZombiYasam>().zombiSaglık.GetCan() > other.gameObject.GetComponent<ZombiYasam>().zombiSaglık.GetCan())
                if ((Vector3.Distance(team1inHedef.transform.position, kale1.transform.position)-5) > Vector3.Distance(other.gameObject.transform.position, kale1.transform.position ))
                {  
                    team1inHedef = other.gameObject;
                }
            }
        }
            //Debug.Log("hedef secme trigger ");
            //Başlangıçta sadece zombi modu yapılacağından burası ona göre düzenlendi.
        if (other.CompareTag("Team1Asker") || other.CompareTag("Team1Kale"))
        {
                if (zombilerinHedef == null)
                {
                    zombilerinHedef = other.gameObject;
                }
               else if(zombilerinHedef.CompareTag("Team1Kale") && other.CompareTag("Team1Asker"))
                {
                zombilerinHedef = other.gameObject;
                }
                else if(zombilerinHedef.CompareTag("Team1Asker")&& other.CompareTag("Team1Asker"))
                {
                
                if (zombilerinHedef.GetComponent<AskerYasam>().askerSaglık.GetCan() > other.gameObject.GetComponent<AskerYasam>().askerSaglık.GetCan())
                        {
                            zombilerinHedef = other.gameObject;
                        }
                }
        }


        if (other.CompareTag("Team2Asker"))
        {

        }
 
           
    }
}

