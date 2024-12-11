using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BallController : MonoBehaviour
{
    [SerializeField] float force = 10f;
    [SerializeField] float delay = 3f;
    [SerializeField] float MIN_INITIAL_Y = -3f;
    [SerializeField] float MAX_INITIAL_Y = 3f;
    [SerializeField] float MIN_ANG = -30f;
    [SerializeField] float MAX_ANG = 30f;

    [SerializeField] GameManager manager;

    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(StartMovement(Random.Range(0, 2) == 0 ? -1 : 1));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;

        if (tag == "Player1" || tag == "Player2")
        {
            float force = transform.position.y - other.transform.position.y;
            if (force > 10) 
                force = 10;
            if (force < -10)
                force = -10;

            rb.AddForceY(force*5,ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Meta2")
        {
            manager.AddPointP1();
            Restart(1);
        }
        else if (other.gameObject.tag == "Meta1")
        {
            manager.AddPointP2();
            Restart(-1);
        }
    }

    void Restart(int dirX){

        rb.linearVelocity = Vector2.zero;
        transform.position = new Vector3(0, Random.Range(MIN_INITIAL_Y,MAX_INITIAL_Y), 0);

        StartCoroutine(StartMovement(dirX));
    }

    IEnumerator StartMovement(int dirX){
        yield return new WaitForSeconds(delay);

        Debug.Log("LANZADO");
        float angulo = Random.Range(MIN_ANG, MAX_ANG) * Mathf.Deg2Rad;
        float x = Mathf.Cos(angulo) * dirX; 

        int direccionY = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Mathf.Sin(angulo) * direccionY;
        
        //rb.velocity = Vector2.zero;  // obsoleto desde Unity 6
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(new Vector2(x, y) * force, ForceMode2D.Impulse);
    }
}
