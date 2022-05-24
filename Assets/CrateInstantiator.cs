using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateInstantiator : MonoBehaviour
{

    public GameObject crate;
    public int n;
    public int fold;
    public float dist = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        for(var k = 0; k < fold; k++) {
            for(var i = 0; i < n; i++) {
                for(var j = 0; j < n; j++) {
                    Instantiate(crate, new Vector3(j * dist, k, i * dist), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
