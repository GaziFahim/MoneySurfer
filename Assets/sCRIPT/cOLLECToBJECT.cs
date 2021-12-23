using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cOLLECToBJECT : MonoBehaviour
{
    bool iSObject;
    int index;
    public cube cb;
    void Start()
    {
        iSObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (iSObject == true)
        {

            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index, 0);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "obstacle")
        {
            cb.obstaclefun();
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(this.gameObject);
        }
    }
    public bool IsactiveObject()
    {
        return iSObject;
    }

    public void Objectmain()
    {
        iSObject = true;
    }
    public void IndexOb(int index)
    {
        this.index = index;
    }
}
