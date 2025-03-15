using UnityEngine;
using System.Collections;

public class TNT : MonoBehaviour
{
    private Animator anim;
    public GameObject explosion;
    public CameraShake cameraShake;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("TNT_Fuse");
        Invoke(nameof(Explode), anim.GetCurrentAnimatorStateInfo(0).length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitAndExplode()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        Explode();
    }

    public void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        cameraShake.Shake(1.0f);
        Destroy(gameObject);
    }
}
