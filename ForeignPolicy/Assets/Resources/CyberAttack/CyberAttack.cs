using UnityEngine;
using System.Collections;

public class CyberAttack : MonoBehaviour
{
	public Transform target;
	
	public float MissileSpeed;
	private float turn = 2.5f;
	private float lastTurn = 0f;

	private Rigidbody2D cyberAttackRigidbody;
    

	void Awake()
	{
        cyberAttackRigidbody = GetComponent<Rigidbody2D>();
	}
	
	void Start()
	{
		Invoke ("Explode", 50f);
        target = GameObject.Find("GameWorld").GetComponent<WorldManagement>().GetSelectedCountry().transform;
        cyberAttackRigidbody.transform.position = GameObject.Find("GameWorld").GetComponent<WorldManagement>().GetHomeCountry().transform.position;
    }
	
	void FixedUpdate()
	{			
        
       
        Quaternion newRotation = Quaternion.LookRotation(transform.position - target.position, Vector3.forward);
		newRotation.x = 0.0f;
		newRotation.y = 0.0f;
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * turn);
        cyberAttackRigidbody.velocity=transform.up * MissileSpeed;
		if(turn<40f)
		{
			lastTurn+=Time.deltaTime*Time.deltaTime*50f;
			turn+=lastTurn;
		}
	}
	
	private void Explode()
	{
		CancelInvoke("Explode");
		Destroy(gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
        if(target.GetComponent<PolygonCollider2D>().OverlapPoint(cyberAttackRigidbody.transform.position))
        {
            Explode();
        }
	}
}
