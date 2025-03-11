using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public int BarrelHitPoints;
    public GameObject explosion;
    public CameraShake cameraShake;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BarrelHitPoints <= 0)
        {
            Explode();
        }
    }

    public void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        cameraShake.Shake(1.0f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Explosive"))
        {
            Explode();
        }
    }
}
