using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GunController : MonoBehaviour
{
    [SerializeField] Transform bullet_point;
    [SerializeField] GameObject bulletPrefab;
    //�q�[�ɁA�J�ΊԊu�A�J�ΊԊu�v��
    [SerializeField] int bullet_count = 10;
    [SerializeField] float shoot_interval = 0.2f;
    [SerializeField] float shoot_interval_timer = 0;
    [SerializeField] TextMeshProUGUI bulletCountText;
    void Start()
    {
    }
    void Update()
    {
        shoot_interval_timer += Time.deltaTime;
        //���B�J�ΊԊu�����������L�q�[
        if (shoot_interval_timer >= shoot_interval && Input.GetMouseButton(0) && bullet_count > 0)
        {
            shoot_interval_timer = 0;
            Instantiate(bulletPrefab, bullet_point.position, bullet_point.rotation);
            bullet_count--;
            updateBulletUI();
            if (bullet_count == 0)
            {
                //���q�[2�b�㊷�q�[
                Invoke("Reload", 2f);
                GetComponent<Animator>().SetTrigger("changeBullet");
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            bullet_count = 0;
            Invoke("Reload", 2f);
            GetComponent<Animator>().SetTrigger("changeBullet");
        }
    }
    private void Reload()
    {
        bullet_count = 10;
        updateBulletUI();
    }
    private void updateBulletUI()
    {
        bulletCountText.text = bullet_count.ToString();
    }
}
