using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //子彈的速度
        GetComponent<Rigidbody>().AddForce(transform.forward*800);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //碰到即銷毀
        Destroy(gameObject);
    }
}
