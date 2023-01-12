using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardLogic : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector2 turn;
    public float sensitivity = 1.5f;
    public GameObject camera;
    public GameObject menu;
    public static bool menuHidden = false;
    public float DelayTimer = 0.2f;
    private float timestamp;

    IEnumerator ExampleCoroutine(int x)
    {
        //yield on a new YieldInstruction that waits for x seconds.
        yield return new WaitForSeconds(x);
    }

    // Update is called once per frame
    void Update()
    {
        //Movment manager
        if (menuHidden)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                camera.transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.Q))
            {
                camera.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.S))
            {
                camera.transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.D))
            {
                camera.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.Space))
            {
                camera.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                camera.transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {
                turn.x += Input.GetAxis("Mouse X") * sensitivity;
                turn.y += Input.GetAxis("Mouse Y") * sensitivity;
                camera.transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
            }
        }
        //Menu manager
        if (Input.GetKey(KeyCode.Escape) && Time.time > timestamp)
        {
            if (menuHidden)
            {
                //show menu
                menuHidden = false;
                menu.SetActive(true);
            }
            else
            {
                //hide menu
                menuHidden = true;
                menu.SetActive(false);
            }
            timestamp = Time.time + DelayTimer;
        }
    }
}

