using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour {

    public float dodge;
    public float smoothing;
    public float tilt;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 manueverWait;
    public Boundary boundary;

    

    private float currentSpeed;
    private float targetManeuver;
    private Rigidbody rbb;



	void Start ()
    {
        rbb = GetComponent<Rigidbody>();
       
        currentSpeed = rbb.velocity.z;
        StartCoroutine(Evade());
	}


   IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range (startWait.x, startWait.y));


        while (true)
        {
             targetManeuver = Random.Range(1,dodge)* -Mathf.Sign(transform.position.x);
           
            yield return new WaitForSeconds(Random.Range(maneuverTime.x,maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(manueverWait.x,manueverWait.y));

        }

    }
	void FixedUpdate ()
    {
        float newManeuver = Mathf.MoveTowards(rbb.velocity.x,targetManeuver,Time.deltaTime* smoothing);
        rbb.velocity = new Vector3(newManeuver,0.0f,currentSpeed);

        //prevents ship from going out of boundary;
        rbb.position = new Vector3(Mathf.Clamp(rbb.position.x,boundary.xMin,boundary.xMax),
                                        0.0f,
                                        Mathf.Clamp(rbb.position.z,boundary.zMin,boundary.zMax)
                                  );

        rbb.rotation = Quaternion.Euler(0.0f,0.0f,rbb.velocity.x* -tilt);

    }
}
