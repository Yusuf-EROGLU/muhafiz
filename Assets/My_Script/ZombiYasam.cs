using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiYasam : MonoBehaviour
{
    public SaglikSistemi zombiSaglık;
    public int baslangıcCan;
    public float deger;
    NavMeshAgent agent;
    Animator animator;
    Vector3 yon;
    Quaternion bakısYonu;
    public float donmeHızı;
    public float saniyeHasar;
    SaglikSistemi dusmanSaglık;
    public float iyilesmeMiktarı;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        zombiSaglık = new SaglikSistemi(baslangıcCan);
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (HedefSecme.zombilerinHedef != null)
        {
            agent.SetDestination(HedefSecme.zombilerinHedef.transform.position);
            // Debug.Log("asker hedef atandı");


            if (agent.remainingDistance < agent.stoppingDistance)          
            {
                agent.isStopped = true;
                animator.SetBool("Yuru", false);
                animator.SetBool("AtesEt", true);
                animator.SetBool("Ol", false);
                DusmanaDon(HedefSecme.zombilerinHedef);
                // Debug.Log(this.name + "   durdu!!!!!!!!!!");
            }
            else if (agent.remainingDistance > agent.stoppingDistance || HedefSecme.zombilerinHedef == null)         
            {
            agent.isStopped = false;
            animator.SetBool("Yuru", true);
            animator.SetBool("AtesEt", false);
            animator.SetBool("Ol", false);
            }

          if (zombiSaglık.GetCan() == 0)
          {
            
            animator.SetBool("Yuru", false);
            animator.SetBool("AtesEt", false);
            animator.SetBool("Ol", true);
            Destroy(this.gameObject, 4f);
                
          }
        }

        Debug.Log("zombi saglık" + zombiSaglık.GetCan());

    }
    // Update is called once per frame
  
    private void DusmanaDon(GameObject hedef)
    {
        yon = (hedef.transform.position - transform.position).normalized;
        bakısYonu = Quaternion.LookRotation(yon);
        transform.rotation = Quaternion.Slerp(transform.rotation, bakısYonu, Time.deltaTime * donmeHızı);
    }

    private void OnTriggerStay(Collider other)
    { if (other.gameObject != null && HedefSecme.zombilerinHedef != null)
        {
            if (other.name == HedefSecme.zombilerinHedef.name && other.gameObject.CompareTag("Team1Asker"))
            {
                dusmanSaglık = other.gameObject.GetComponent<AskerYasam>().askerSaglık;
                // Debug.Log("damage vuruluyor");
                //saniyede damage vursun diye yapıldı.
                // Debug.Log("timefixed:"+(Time.fixedTime)+ "  timefixedDeltatime: "+Time.fixedDeltaTime+ "  timedeltatime: " + Time.deltaTime);
                dusmanSaglık.Hasar((saniyeHasar * (Time.fixedDeltaTime)));
                zombiSaglık.Iyilestir(iyilesmeMiktarı);
            }
        }
    }

    private void OnDestroy()
    {
        KaleYasam.kaleHazine.Kazan(deger);
    }
}
