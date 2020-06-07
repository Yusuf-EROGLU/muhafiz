using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZamanDegistirici : MonoBehaviour
{
    public Slider zamandegistirici;

    public void ZamanDegistir()
    {
        Time.timeScale = zamandegistirici.value;
    }
   
}
