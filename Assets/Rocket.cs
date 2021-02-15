using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 10f;

    Vector3 startVector = new Vector3(0.0f, 1.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = new Vector3 (
            transform.position.x,
            transform.position.y + 10,
            Camera.main.transform.position.z );

        if (Input.GetKey(KeyCode.S)) {

            transform.position = startVector * 3;

        }

        Thrust();
        Rotate(); 
    }

    void Thrust() {

        if (Input.GetKey(KeyCode.Space)) {
            print("thrusting ");
            float thrustSpeed = mainThrust;
            rigidBody.AddRelativeForce(Vector3.up * thrustSpeed);

            if (!audioSource.isPlaying) {
                audioSource.Play();
            }

             
        } else if (Input.GetKeyUp(KeyCode.Space)) {
            if (audioSource.isPlaying) {
                audioSource.Stop();
            }
        } 
    }

    void PerformeRotation(int direction) {

        float rotationSpeed = rcsThrust * Time.deltaTime;

        // We have got manual controll here and need to freeze fisical rotation
        rigidBody.freezeRotation = true;

        transform.Rotate(direction * Vector3.forward * rotationSpeed);

        rigidBody.freezeRotation = false; 

    }

    void Rotate() {
        
        if (Input.GetKey(KeyCode.A)) {

            PerformeRotation(1);

        } else if (Input.GetKey(KeyCode.D)) {

            PerformeRotation(-1);

        }

    }
}
