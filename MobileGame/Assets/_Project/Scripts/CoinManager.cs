using System.Collections;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;

    [SerializeField] private float spawnDelay = 3f;
    [SerializeField] private float coinLifetime = 10f;

    private bool canSpawnCoin = true;

    void Update()
    {
        if (canSpawnCoin)
        {
            StartCoroutine(SpawnCoin());
            canSpawnCoin = false;
        }
    }

    IEnumerator SpawnCoin()
    {
        yield return new WaitForSeconds(spawnDelay);

        Vector3 spawnX0 = new Vector3(0, spawnPoint1.transform.position.y, spawnPoint1.transform.position.z);
        Vector3 spawnX1 = new Vector3(1, spawnPoint1.transform.position.y, spawnPoint1.transform.position.z);
        Vector3 spawnX1menos = new Vector3(-1, spawnPoint1.transform.position.y, spawnPoint1.transform.position.z);

        //Transform spawnEscolhido = Random.value == 0 ? spawnX0 : spawnPoint2;
        int valor = Random.Range(-1, 2);
        if (valor == 0)
        {
            GameObject coinInstance = Instantiate(coinPrefab, spawnX0, Quaternion.identity);
            Destroy(coinInstance, coinLifetime);
        }
        if (valor == 1)
        {
            GameObject coinInstance = Instantiate(coinPrefab, spawnX1, Quaternion.identity);
            Destroy(coinInstance, coinLifetime);
        }
        if (valor == -1)
        {
            GameObject coinInstance = Instantiate(coinPrefab, spawnX1menos, Quaternion.identity);
            Destroy(coinInstance, coinLifetime);
        }



        canSpawnCoin = true;
    }
}