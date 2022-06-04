using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Bomb : MonoBehaviour
{

    public float time = 3;
    bool exploded = false;
    public GameObject explosion;
    public float radius = 6f;
    public float explosionForce = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time < 0f && !exploded) {
            explode();
            this.exploded = true;
        }
    }

    void explode() {
        var explosionObject = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(explosionObject,2f);

        Collider[] crates = Physics.OverlapSphere(transform.position,radius);

        foreach(Collider crate in crates) {
            Destructible destructible = crate.GetComponent<Destructible>();
            if(destructible != null) {
                destructible.Destroy();
            }
        }

        Collider[] pieces = Physics.OverlapSphere(transform.position,radius);

        foreach(Collider piece in pieces) {
            Rigidbody rb = piece.GetComponent<Rigidbody>();
            if(rb != null) {
                rb.AddExplosionForce(explosionForce, transform.position, radius);
            }
        }

        Destroy(gameObject);
    }
}
