using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 200f;
    [SerializeField] TextMeshProUGUI HPtext;
    [SerializeField] int Hp = 10;
    private Rigidbody rb;
    private bool isToachGround;
    [SerializeField] GameObject mainMenu;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �v�Z�ړ�����
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // �����ړ������ړ��p�F
        if (moveDirection != Vector3.zero)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
        //���󔒌����ݒn�����Ȓ�
        if (Input.GetKeyDown(KeyCode.Space) && isToachGround == true)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isToachGround = true;
        }
        if (collision.collider.tag == "Enemy")
        {
            Hp=Hp-2;
            updateHPtext();
            if (Hp <= 0)
            {
                Time.timeScale = 0f;
                mainMenu.active = true;
                Cursor.visible = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isToachGround = false;
        }
    }
    private void updateHPtext()
    {
        HPtext.text = Hp.ToString();
    }
}
