using System.Collections;
using UnityEngine;

public class ObstaculeManager : MonoBehaviour
{
    [SerializeField] GameObject Obstacule;
    [SerializeField] Transform ObstaculeSpawn1;
    [SerializeField] Transform ObstaculeSpawn2;


    public bool canSpawnObstacule = true;
    void Start()
    {
        
    }


    void Update()
    {
        if (canSpawnObstacule == true)
        {
            StartCoroutine(SpawnObstacule());
            canSpawnObstacule = false;
        }
    }

    IEnumerator SpawnObstacule()
    {
        yield return new WaitForSeconds(3);

        Transform spawnEscolhido = Random.value > 0.5f ? ObstaculeSpawn1 : ObstaculeSpawn2;

        GameObject obstaculeInstance = Instantiate(Obstacule, spawnEscolhido.position, Quaternion.identity);
        Destroy(obstaculeInstance, 10);

        canSpawnObstacule = true;
    }
}
