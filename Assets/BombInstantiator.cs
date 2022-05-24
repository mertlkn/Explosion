using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInstantiator : MonoBehaviour
{
    public GameObject bomb;
    public int multiplier;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator wait() {
        yield return new WaitForSeconds(2);
        var n = GameObject.FindWithTag("CrateInstantiator").GetComponent<CrateInstantiator>().n;
        var dist = GameObject.FindWithTag("CrateInstantiator").GetComponent<CrateInstantiator>().dist;
        var bombDist = (n * dist) / (multiplier + 1);
        for(var i = 0; i<multiplier; i++) {
            for(var j = 0; j<multiplier; j++) {
                Instantiate(bomb, new Vector3(j * bombDist,5f, i * bombDist), Quaternion.identity);
            }
        }
    }
}
