using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KaleYasam : MonoBehaviour
{
    public float saniyeHasar;
    public float kaleCan;
    public float kalesayac;
    public float baslangıcPara;
    public static ParaSistemi kaleHazine;
    public Text kaleCanGostergesi;
    public Text paraGostergesi;


    SaglikSistemi dusmanSaglık;
    SaglikSistemi kalesSaglık;
    bool saldirivar;


    private void Awake()   
    {
        
        kalesSaglık = new SaglikSistemi(kaleCan);
    }
    // Start is called before the first frame update
    void Start()
    {

        kaleHazine = new ParaSistemi(baslangıcPara);
        saldirivar = false;
    }

    // Update is called once per frame
    void Update()
    {

      //  Debug.Log(Time.fixedDeltaTime + "-------" + Time.fixedDeltaTime);

        if(saldirivar)
        {
            kaleCan -=Time.deltaTime;
        }

       // Debug.Log("kale can;" + kaleCan);
        kaleCanGostergesi.text = "Kale Canı:" + (int)kaleCan;
        paraGostergesi.text = "Hazine: " + kaleHazine.Getpara();

    }

    private void OnTriggerExit(Collider other)
    {
        saldirivar = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            
            dusmanSaglık = other.gameObject.GetComponent<ZombiYasam>().zombiSaglık;

            //saniyede damage vursun diye yapıldı.
            dusmanSaglık.Hasar((saniyeHasar * (Time.fixedDeltaTime)));
            saldirivar = true;
            
           


            //Debug.Log(Time.fixedDeltaTime + "-------"+ Time.fixedDeltaTime);
        }
        
    }



}
