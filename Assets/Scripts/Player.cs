using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    float jumpForce = 3.3f;
    private Rigidbody Physics;

    [SerializeField]
    int playerSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        Physics = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.forward * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Physics.AddForce(new Vector3(0,jumpForce,0), ForceMode.Impulse);
        }
        
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "obstaculos")
        {
            Destroy(gameObject);
            Debug.Log("Perdiste");
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ganar"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
            Debug.Log("ganaste");
        }
    }

}
