using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Enemy : MonoBehaviour
{
    [SerializeField] int HP = 5;
    public Transform player_transform;
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float detectionRange = 10f;
    private bool isToach;
    private bool isDie;
    Animator am;
    public TextMeshProUGUI Score_text;
    void Start()
    {
        am = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDie)
        {
            if (DetectPlayer())
            {

                if (isToach)
                {
                    // 敵人和玩家接觸後停下攻擊
                    moveSpeed = 0f;
                    am.SetBool("findPlayer", false);
                    am.SetTrigger("Attack");
                }
                else
                {
                    moveSpeed = 1.0f;
                    am.SetBool("findPlayer", true);
                    MoveToPlayer();
                }
            }
            else
            {
                am.SetBool("findPlayer", false);
            }
        }
    }
    private bool DetectPlayer()
    {
        // 計算玩家和敵人的距離
        float distanceToPlayer = Vector3.Distance(transform.position, player_transform.position);
        return distanceToPlayer <= detectionRange;
    }
    private void MoveToPlayer()
    {
        //從敵人的點移動到玩家的點，在兩點之間進行線性插值
        transform.position = Vector3.MoveTowards(transform.position, player_transform.position, moveSpeed * Time.deltaTime);
        //讓敵人面向玩家
        transform.LookAt(player_transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isDie)
        {
            if (other.gameObject.tag == "bullet")
            {
                HP--;
                if (HP <= 0)
                {
                    isDie = true;
                    die();
                }
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isToach = true;
            Debug.Log("isToach = true");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isToach = false;
            Debug.Log("isToach = false");
        }
    }
    private void die()
    {
        moveSpeed = 0f;
        am.SetBool("findPlayer", false);
        am.SetBool("die", true);
        //updateScore
        int newScore = int.Parse(Score_text.text) + 1;
        Score_text.text = newScore.ToString();
        //為了播放動畫，延後毀掉物件
        Invoke("Destoryself", 1.5f);
    }
    private void Destoryself()
    {
        Destroy(gameObject);
    }
}
