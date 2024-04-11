using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Rigidbody targetRb;
    GameManager gameManager;
    private Animator playerAnim;
    float minSpeed = 12;
    float maxSpeed = 14;
    float maxTorque = 10;
    float xRange = 7;
    float ySpawnPos = -6;
    public int pointValue;
    public ParticleSystem explosionParticle;
    public bool isDestroyed;
    
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();  
        playerAnim = GetComponent<Animator>();

        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        playerAnim.SetTrigger("Run_Static");
    }

    public void OnMouseExit()
    {
        if (gameManager.isGameActive && Input.GetKey(KeyCode.Mouse0))
        {
            isDestroyed = true;
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
            gameManager.PlaySound(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.PlaySound(pointValue);
            gameManager.GameOver();
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    
}
