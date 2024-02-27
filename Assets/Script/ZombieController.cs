using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieController : MonoBehaviour
{
    [SerializeField] int minGenerateZombie = 3;
    [SerializeField] int maxGenerateZombie = 10;
    [SerializeField] float GenerateInterval = 20f;
    private float timer;
    [SerializeField] GameObject[] zombiePrefab;
    [SerializeField] Transform Player_transform;
    [SerializeField] TextMeshProUGUI Score_text;
    // Start is called before the first frame update
    void Start()
    {
        GenerateZombie();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= GenerateInterval)
        {
            timer = 0;
            GenerateZombie();
        }
    }
    void GenerateZombie()
    {
        int GenerateZombieCount = Random.Range(minGenerateZombie, maxGenerateZombie + 1);
        for (int i = 0; i < GenerateZombieCount; i++)
        {
            int tempZombiePrefabIndex = Random.Range(0, zombiePrefab.Length);
            GameObject newZombie = Instantiate(zombiePrefab[tempZombiePrefabIndex], new Vector3(Random.Range(-40, 11), 0.5f, Random.Range(-55, 22)), Quaternion.identity, transform);
            newZombie.GetComponent<Enemy>().player_transform = Player_transform;
            newZombie.GetComponent<Enemy>().Score_text = Score_text;
        }
    }
}
