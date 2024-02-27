using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera1 : MonoBehaviour
{
    // ŠŠ‘lèË•q“x
    public float sensitivityHor = 5f;
    public float sensitivityVer = 3f;
    // ã‰ºÅ‘å‹Šp
    public float upper = -60f;
    // ã‰ºÅ¬‹Šp
    public float downver = 60f;
    // ùçzŠp“x
    public float rotver;

    [SerializeField] GameObject Gun;
    [SerializeField] Transform bull_point;
    void Start()
    {
        //“¾“ã…x²çz“IŠp“xC–çA¥ã‰º‹Šp“IŠp“x
        rotver = transform.eulerAngles.x;
        //èªåUŠŠ‘l
        Cursor.visible = false;
    }

    void Update()
    {
        // Šl“¾ŠŠ‘l“IÀ•W
        float mouseHor = Input.GetAxis("Mouse X");
        float mouseVer = Input.GetAxis("Mouse Y");
        // ŒvZùçzŠp“xCŠŠ‘lŒüã¥‹ŠpŒü‰ºC”½”VC‘Š”½B
        rotver -= mouseVer * sensitivityVer;
        //’²®ã‰º‹Šp“I”Íš¡C–h~‘Š‹@çz‰ß“ª
        rotver = Mathf.Clamp(rotver, upper, downver);

        //T§‘Š‹@“Iã‰º‹ŠpC‘Š›”‰—•ƒ•¨Œ(Šß‰Æ)Cã…x²ùçz
        transform.localEulerAngles = new Vector3(rotver, 0, 0);
        //‹Špã‰º“®C‘„–ç—v“®
        Gun.transform.localEulerAngles = new Vector3(rotver, 0, 0);
        //‹Špã‰º“®Cá¢Ëqœ[ˆÊ’u–ç—v“®
        bull_point.localEulerAngles = new Vector3(rotver, 0, 0);
        //‘Š‹@“I¶‰E‹Šp
        transform.parent.Rotate(Vector3.up * mouseHor);

        //èªåUŠŠ‘l
        //Cursor.visible = false;
    }
}