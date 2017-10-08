using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{

    public float xMin, xMax, zMin, zMax;

}







public class PlayerController : MonoBehaviour {

    public float speed;
    
    public float tilt;
    private Rigidbody rb;
  
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;

    
    public float fireRate =0.5F;
    private float nextFire=0.5F ;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }


    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)

        {
            AudioSource audioo = GetComponent<AudioSource>();
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

            audioo.Play();
        }

           


        
    }









    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.velocity = movement * speed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));


        rb.rotation = Quaternion.Euler(0.0f,0.0f,rb.velocity.x*-tilt);












    }


}

