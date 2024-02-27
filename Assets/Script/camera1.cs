using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera1 : MonoBehaviour
{
    // ���l�˕q�x
    public float sensitivityHor = 5f;
    public float sensitivityVer = 3f;
    // �㉺�ő压�p
    public float upper = -60f;
    // �㉺�ŏ����p
    public float downver = 60f;
    // ���z�p�x
    public float rotver;

    [SerializeField] GameObject Gun;
    [SerializeField] Transform bull_point;
    void Start()
    {
        //�����x���z�I�p�x�C��A���㉺���p�I�p�x
        rotver = transform.eulerAngles.x;
        //��U���l
        Cursor.visible = false;
    }

    void Update()
    {
        // �l�����l�I���W
        float mouseHor = Input.GetAxis("Mouse X");
        float mouseVer = Input.GetAxis("Mouse Y");
        // �v�Z���z�p�x�C���l���㐥���p�����C���V�C�����B
        rotver -= mouseVer * sensitivityVer;
        //�����㉺���p�I�͚��C�h�~���@�z�ߓ�
        rotver = Mathf.Clamp(rotver, upper, downver);

        //�T�����@�I�㉺���p�C������������(�߉�)�C�x�����z
        transform.localEulerAngles = new Vector3(rotver, 0, 0);
        //���p�㉺���C����v��
        Gun.transform.localEulerAngles = new Vector3(rotver, 0, 0);
        //���p�㉺���Cᢎˎq�[�ʒu��v��
        bull_point.localEulerAngles = new Vector3(rotver, 0, 0);
        //���@�I���E���p
        transform.parent.Rotate(Vector3.up * mouseHor);

        //��U���l
        //Cursor.visible = false;
    }
}