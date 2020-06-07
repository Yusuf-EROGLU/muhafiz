using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiYaratıcı : MonoBehaviour
{
    public GameObject zombiNormal;
    public GameObject zombiHero;
    public int baslangiczorluk;


    //Bu kodda normalde "Coroutine" kullanılması lazım fakat zaman sıkıntısından dolayı ona girmedim


    private void Awake()
    {
     
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ZombiYarat", 0, 15);
        
        InvokeRepeating("ZombiYarat", 60, 30);
        
        InvokeRepeating("ZombiYarat", 120, 50);
        
        InvokeRepeating("ZombiYarat", 180, 70);
        
        InvokeRepeating("ZombiHeroYarat", 60, 60);

        InvokeRepeating("ZombiHeroYarat", 180, 72);


    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ZombiYarat()
    {
        Instantiate(zombiNormal, transform.position, transform.rotation);
    }


    public void ZombiHeroYarat()
    {
        Instantiate(zombiHero, transform.position, transform.rotation);
    }

    




}
