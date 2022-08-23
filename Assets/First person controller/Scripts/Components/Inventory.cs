using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Camera _camera;
    public float range = 3f;
    public int slot = 0;
    public List<Image> _images;
    public List<GameObject> items;
    private void Start()
    {
        slot = 0;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Interacturar();
        }
    }
    void Interacturar()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.tag == "Item" && slot < 2)
            {
                hit.collider.gameObject.SetActive(false);
                _images[slot].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                Debug.Log(slot);
                slot++;
            }
            
        }
    }
}
