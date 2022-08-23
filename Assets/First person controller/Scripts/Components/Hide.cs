using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hide : MonoBehaviour
{
    public Rigidbody rb;
    public List<GameObject> escondites;
    public Vector3 escondite;
    public float distance = 1f;
    public CapsuleCollider capsule;
    public GameObject panelF;
    public FirstPersonMovement fpm;
    public Vector3 beforePosition;
    public bool trigger;
    public bool isHide;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
        fpm = GetComponent<FirstPersonMovement>();
    }
    void Update()
    {
        BuscarEscondite();
        if (Input.GetKeyDown(KeyCode.F) && trigger == true && isHide == false)
        {
            beforePosition = transform.position;
            capsule.isTrigger = true;
            rb.isKinematic = true;
            fpm.enabled = false;
            transform.position = escondite;
            isHide = true;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F) && trigger == true && isHide == true)
            {
                capsule.isTrigger = false;
                rb.isKinematic = false;
                fpm.enabled = true;
                transform.position = beforePosition;
                isHide = false;
            }
        }
    }
    void BuscarEscondite()
    {

        foreach (GameObject i in escondites)
        {
            float distancia = Vector3.Distance(transform.position, i.transform.position);
            if (distancia < distance)
            {
                escondite = i.transform.position;
            }
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "escondite")
    //    {
    //        escondite.position = other.transform.position;
    //    }
    //}
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "escondite")
        {
            panelF.SetActive(true);
            
            trigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "escondite")
        {
            panelF.SetActive(false);
            
            trigger = false;
        }
    }
}