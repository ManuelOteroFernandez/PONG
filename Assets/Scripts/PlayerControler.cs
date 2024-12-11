using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    [SerializeField] float MAX_Y = 4f;
    [SerializeField] float MIN_Y = -4f;
    [SerializeField] float speed = 0.5f;
    
    void Update()
    {
        if( (
                (Input.GetKey("up") && gameObject.CompareTag("Player2")) || 
                (Input.GetKey("w") && gameObject.CompareTag("Player1")) 
            ) && transform.position.y < MAX_Y) {

                transform.Translate(speed * Time.deltaTime * Vector3.up);
        
        } else if( (
                    (Input.GetKey("down") && gameObject.CompareTag("Player2")) || 
                    (Input.GetKey("s") && gameObject.CompareTag("Player1"))
                ) && transform.position.y > MIN_Y) {

                transform.Translate(speed * Time.deltaTime * -Vector3.up);
        }
        
    }
}
