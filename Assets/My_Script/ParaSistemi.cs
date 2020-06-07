using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaSistemi : MonoBehaviour
{
    private float para;
    private float baslangıcParası;
    public ParaSistemi(float baslangıcParası)
    {
        this.baslangıcParası = baslangıcParası;
        para = baslangıcParası;
    }
    public float Getpara()
    {
        return para;
    }
    public void Harca(float ucreti)
    {
        if (para > 0)
        {
            para = para - ucreti;
        }
    }
    public void Kazan(float degeri)
    {
        para = para + degeri;
      
    }
    

}
