using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public Rigidbody rb;
    public Transform escondite;
    public CapsuleCollider capsule;
    public bool hidden = false;
    public GameObject panelF;
    public bool canHide = true;
    public string hola;
    public FirstPersonMovement fpm;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
        fpm = GetComponent<FirstPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Hiding()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(canHide && !hidden)
            {
                hidden = true;
                capsule.isTrigger = true;
                rb.isKinematic = true;
                fpm.enabled = false;
                transform.position = escondite.position;
                StartCoroutine(CoolDownHide());
                

            }
            if(canHide && hidden)
            {
                hidden = false;
                capsule.isTrigger = false;
                rb.isKinematic = false;
                fpm.enabled = true;
                transform.position += transform.up;
                StartCoroutine(CoolDownHide());
                
            }
            
            
        }
    }
    IEnumerator CoolDownHide()
    {
        canHide = false;
        yield return new WaitForSeconds(0.2f);
        canHide = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "escondite")
        {
            panelF.SetActive(true);
            Hiding();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "escondite")
        {
            panelF.SetActive(false);
        }
    }
}
