using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GunController : MonoBehaviour
{
    [SerializeField] Transform bullet_point;
    [SerializeField] GameObject bulletPrefab;
    //Žqœ[ÉAŠJ‰ÎŠÔŠuAŠJ‰ÎŠÔŠuŒvÉ
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
        //“ž’BŠJ‰ÎŠÔŠuŠŽˆÂ‰º¶Œ®ŠŽ—LŽqœ[
        if (shoot_interval_timer >= shoot_interval && Input.GetMouseButton(0) && bullet_count > 0)
        {
            shoot_interval_timer = 0;
            Instantiate(bulletPrefab, bullet_point.position, bullet_point.rotation);
            bullet_count--;
            updateBulletUI();
            if (bullet_count == 0)
            {
                //Ÿ“Žqœ[2•bŒãŠ·Žqœ[
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
