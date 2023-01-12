using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class menu_manager : MonoBehaviour
{
    public GameObject container;
    public GameObject board;

    public void add_container(){
        GameObject tempGo = Instantiate(
            container,
            new Vector3(0, 0, 0),
            Quaternion.LookRotation(new Vector3(0, 0, 0)));
        tempGo.transform.parent = board.transform;
        tempGo.tag = "Container";
    }

    public void goToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }

}