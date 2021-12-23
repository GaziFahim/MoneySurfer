using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{


    GameObject player;
    int c;
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position = new Vector3(transform.position.x, c+0.5f, transform.position.z);
        this.transform.localPosition = new Vector3(0, -c, 0);
    }
    public void obstaclefun()
    {
        c--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "cube" && other.gameObject.GetComponent<cOLLECToBJECT>().IsactiveObject() == false)
        {
            c += 1;
            other.gameObject.GetComponent<cOLLECToBJECT>().Objectmain();
            other.gameObject.GetComponent<cOLLECToBJECT>().IndexOb(c);
            other.gameObject.transform.parent = player.transform;
        }
    }
}
