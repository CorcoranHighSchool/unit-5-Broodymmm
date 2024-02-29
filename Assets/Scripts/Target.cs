using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public ParticleSystem explosionParticale;

    private GameManger gameManger;

    public int pointValue;

    private Rigidbody targetRb;

    private float minSpeed = 12;

    private float maxSpeed = 16;

    private float maxTorque = 10;

    private float xRange = 4;

    private float ySpawnPos = -6;

    
    // Start is called before the first frame update
    void Start()
    {
        gameManger = FindObjectOfType<GameManger>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(Vector3.up * Random.Range(12, 16), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);

        transform.position = new Vector3(Random.Range(-4, 4), -6);
    }
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    private Vector3 RandomTorque()
    {
        return Vector3.up * Random.Range(-maxTorque, maxTorque);
    }
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameManger.UpdateScore(pointValue);
        Instantiate(explosionParticale, transform.position, explosionParticale.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManger.GameOver();
        }
    }
}
