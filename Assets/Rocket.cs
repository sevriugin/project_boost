using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate(); 
    }

    void Thrust() {

        if (Input.GetKey(KeyCode.Space)) {
            print("thrusting ");
            rigidBody.AddRelativeForce(Vector3.up);

            if (!audioSource.isPlaying) {
                audioSource.Play();
            }

             
        } else if (Input.GetKeyUp(KeyCode.Space)) {
            if (audioSource.isPlaying) {
                audioSource.Stop();
            }
        } 
    }

    void Rotate() {

        rigidBody.freezeRotation = true; // we have got manual controll here and need to freeze fisical rotation
        
        if (Input.GetKey(KeyCode.A)) {
            print("rotaiting left ");
            transform.Rotate(Vector3.forward);
        } else if (Input.GetKey(KeyCode.D)) {
            print("rotaiting right ");
            transform.Rotate(-Vector3.forward);
        }

        rigidBody.freezeRotation = false;

    }
}
