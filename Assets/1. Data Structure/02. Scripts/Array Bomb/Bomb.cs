using System;
using System.Collections;
using UnityEngine;


public class Bomb : MonoBehaviour
{
    public float bombTime = 4f;
    public float bombRange = 10f;
    public LayerMask layerMask;
    
    private Rigidbody bomb_Rb;
    
    void Awake()
    {
        bomb_Rb = GetComponent<Rigidbody>();
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(bombTime);

        BombForce();
    }

    private void BombForce()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, bombRange, layerMask);

        foreach (var col in colliders)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();

            //AddExplosionForce(Æø¹ß ÆÄ¿ö, Æø¹ß À§Ä¡, Æø¹ß ¹üÀ§, Æø¹ß ³ôÀÌ)
            rb.AddExplosionForce(500f, transform.position, bombRange, 1f);
        }

        Destroy(gameObject);
    }
}
