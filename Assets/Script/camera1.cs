using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera1 : MonoBehaviour
{
    // lèËqx
    public float sensitivityHor = 5f;
    public float sensitivityVer = 3f;
    // ãºÅåp
    public float upper = -60f;
    // ãºÅ¬p
    public float downver = 60f;
    // ùçzpx
    public float rotver;

    [SerializeField] GameObject Gun;
    [SerializeField] Transform bull_point;
    void Start()
    {
        //¾ãx²çzIpxCçA¥ãºpIpx
        rotver = transform.eulerAngles.x;
        //èªåUl
        Cursor.visible = false;
    }

    void Update()
    {
        // l¾lIÀW
        float mouseHor = Input.GetAxis("Mouse X");
        float mouseVer = Input.GetAxis("Mouse Y");
        // vZùçzpxClüã¥püºC½VC½B
        rotver -= mouseVer * sensitivityVer;
        //²®ãºpIÍ¡Ch~@çzßª
        rotver = Mathf.Clamp(rotver, upper, downver);

        //T§@IãºpC¨(ßÆ)Cãx²ùçz
        transform.localEulerAngles = new Vector3(rotver, 0, 0);
        //pãº®Cçv®
        Gun.transform.localEulerAngles = new Vector3(rotver, 0, 0);
        //pãº®Cá¢Ëq[Êuçv®
        bull_point.localEulerAngles = new Vector3(rotver, 0, 0);
        //@I¶Ep
        transform.parent.Rotate(Vector3.up * mouseHor);

        //èªåUl
        //Cursor.visible = false;
    }
}