using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AskerYasam : MonoBehaviour
{
    //Bukod Team1 Askerleri için kullanılacak
    public SaglikSistemi askerSaglık;
    public int baslangıcCan;
    NavMeshAgent agent;
    Animator animator;
    Vector3 yon;
    Quaternion bakısYonu;
    public float donmeHızı;
    public float saniyeHasar;
    SaglikSistemi dusmanSaglık;


    private void Awake()
    {
         
    }
    

    void Start()
    {
        askerSaglık = new SaglikSistemi(baslangıcCan);
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        donmeHızı = 10f;
    }

    private void Update()
    {
        if (HedefSecme.team1inHedef != null)
        {
            agent.SetDestination(HedefSecme.team1inHedef.transform.position);
            // Debug.Log("zombi hedef atandı");


            if (agent.remainingDistance < agent.stoppingDistance)
            {
                animator.SetBool("Yuru", false);
                animator.SetBool("AtesEt", true);
                animator.SetBool("Ol", false);
                DusmanaDon(HedefSecme.team1inHedef);
                // Debug.Log(this.name + "   durdu!!!!!!!!!!");
            }
            else if(agent.remainingDistance > agent.stoppingDistance || HedefSecme.team1inHedef == null)
            {
                animator.SetBool("Yuru", true);
                animator.SetBool("AtesEt", false);
                animator.SetBool("Ol", false);
            }
        }



        Debug.Log(askerSaglık.GetCan());
        if (askerSaglık.GetCan() == 0)
        {
            animator.SetBool("Yuru", false);
            animator.SetBool("AtesEt", false);
            animator.SetBool("Ol", true);
            Destroy(this.gameObject, 4f);
        }
        
    }

   

    private void DusmanaDon(GameObject hedef)
    {
        yon = (hedef.transform.position - transform.position).normalized;
        bakısYonu = Quaternion.LookRotation(yon);
        transform.rotation = Quaternion.Slerp(transform.rotation, bakısYonu, Time.deltaTime * donmeHızı);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject != null && HedefSecme.team1inHedef != null)
        {
            if (other.CompareTag("Zombie") && other.gameObject.name == HedefSecme.team1inHedef.name)
            {
                dusmanSaglık = other.gameObject.GetComponent<ZombiYasam>().zombiSaglık;

                //saniyede damage vursun diye yapıldı.
                dusmanSaglık.Hasar((saniyeHasar * (Time.fixedDeltaTime)));
            }
        }
    }

    
}
