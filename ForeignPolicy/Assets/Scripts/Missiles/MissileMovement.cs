using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{

    private Transform target;

    public float MissileSpeed;
    private float turn = 2.5f;
    private float lastTurn = 0f;
    private float time;

    private Rigidbody2D cyberAttackRigidbody;

    // Use this for initialization
    void Awake()
    {
        cyberAttackRigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        time = 5.0f;
        Invoke("Explode", 50f);
        GameObject home = GameObject.Find("GameWorld").GetComponent<WorldManagement>().GetHomeCountry();
        target = GameObject.Find("GameWorld").GetComponent<WorldManagement>().GetSelectedCountry().transform;
        cyberAttackRigidbody.transform.position = new Vector3(home.transform.position.x, home.transform.position.y, -0.1f);
    }

    void FixedUpdate()
    {
        time = time - Time.deltaTime;

        if (time <= 0.0f)
        {
            this.gameObject.SetActive(false);
        }
        Quaternion newRotation = Quaternion.LookRotation(transform.position - target.position, Vector3.forward);
        newRotation.x = 0.0f;
        newRotation.y = 0.0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * turn);
        cyberAttackRigidbody.velocity = transform.up * MissileSpeed;
        if (turn < 40f)
        {
            lastTurn += Time.deltaTime * Time.deltaTime * 50f;
            turn += lastTurn;
        }
    }

    private void Explode()
    {
        CancelInvoke("Explode");
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (target.GetComponent<PolygonCollider2D>().OverlapPoint(cyberAttackRigidbody.transform.position))
        {
            Explode();
            target.GetComponent<CountryStanding>().Deselect();

        }
    }
}
