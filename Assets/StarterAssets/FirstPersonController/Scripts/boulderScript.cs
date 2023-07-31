using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderScript : MonoBehaviour
{
    public Transform PlayerSpawn;
    public Vector3 startPos; 
    Rigidbody rb;
    [Tooltip("adjusts the thrust of the object.")]
    [Range(0, 100)]
    public float thrust = 1;
    public Scorescript score;
    // Start is called before the first frame update
    void Start()
    {
        //grab start position
        startPos = transform.position;
        //use getcompoent to assign ridgid body
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * thrust, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            transform.position = startPos;
            rb.velocity = Vector3.zero; //Vector3(0,0,0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Capsule")
        {
            PlayerSpawn = GameObject.Find("PlayerSpawn").transform;
            collision.gameObject.transform.parent.GetComponent<CharacterController>().enabled = false;
            collision.gameObject.transform.parent.position = PlayerSpawn.position;
            collision.gameObject.transform.parent.GetComponent<CharacterController>().enabled = true;
            score.AddScore();
        }

        if (collision.gameObject.CompareTag("BoulderReset"))
        {
            ResetBoulder();
        }
    }

    void ResetBoulder()
    {
        transform.position = startPos;
        rb.velocity = Vector3.zero; //Vector3(0,0,0);
    }
}
