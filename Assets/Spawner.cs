using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombie;
    public GameObject bigZombie;

    float timer = 0f;
    public bool doTimer = true;
    float timerLimit = 15;

    public void Update()
    {
        if(doTimer)
        {
            timer += Time.deltaTime;
        }

        if (timer >= timerLimit)
        {
            timer = 0;
            GameObject temp;

            if(Random.Range(0, 6f) > 2)
            {
                temp = Instantiate(zombie);
            } else
            {
                temp = Instantiate(bigZombie);          
            }

            temp.transform.position = this.transform.position;
        }
    }

    public void Start()
    {
        GameObject temp;

        if (Random.Range(0, 6f) != 1)
        {
            temp = Instantiate(zombie);
        }
        else
        {
            temp = Instantiate(bigZombie);
        }

        temp.transform.position = this.transform.position;
    }
}
