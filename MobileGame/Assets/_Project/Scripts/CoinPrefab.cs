using UnityEngine;

public class CoinPrefab : MonoBehaviour
{
    [SerializeField] float rotationVelocity = 10f;
    UIManager UIManager;
    private void Start()
    {
        UIManager = FindAnyObjectByType<UIManager>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, rotationVelocity, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlayCoin();
            UIManager.coinCount++;
            Destroy(gameObject);
        }
    }
}
