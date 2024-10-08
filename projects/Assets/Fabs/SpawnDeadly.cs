using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDeadly : MonoBehaviour
{
    public GameObject deadlies;
    public float spawnrate_min = .8f;
    public float spawnrate_max = 1.2f;
    public float spawn_x_min;
    public float spawn_x_max;

    Usefull helper = new Usefull();


    // Start is called before the first frame update
    void Start()
    {
        float aWidth = helper.ObjectPosOnCamera(new Vector3(Screen.width - 20, 0, 0)).x;

        spawn_x_min = -aWidth;
        spawn_x_max = aWidth;

        Spawn();
        StartCoroutine(NextSpawn());
    }

    // Update is called once per frame
    // void Update()
    // {
    //     float spawnrate = spawnrate_min;
    //     if (timer < spawnrate)
    //     {
    //         timer += Time.deltaTime;
    //     }
    //     else
    //     {
    //         Spawn();
    //         timer = 0;
    //     }
    // }

    void Spawn()
    {
        float x_pos = Random.Range(spawn_x_min, spawn_x_max);
        Instantiate(deadlies, new Vector3(x_pos, transform.position.y, transform.position.z), transform.rotation);
    }

    IEnumerator NextSpawn()
    {
        while (true)
        {
            float spawnrate = Random.Range(spawnrate_min, spawnrate_max);

            yield return new WaitForSeconds(spawnrate);
            Spawn();
            yield return new WaitForSeconds(1);
            Spawn();
        }
    }
}
