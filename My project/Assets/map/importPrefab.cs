using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using System;

public class importPrefab : MonoBehaviour
{
    public GameObject modelObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPrefab()
    {

        string assetPath = EditorUtility.OpenFilePanel("Select Model", "", "asset");

        if (assetPath.StartsWith(Application.dataPath)) {
         assetPath=  "Assets" + assetPath.Substring(Application.dataPath.Length);
     }

        if (assetPath.Length == 0) return; // if user click cancel return

        Mesh mesh = AssetDatabase.LoadAssetAtPath<Mesh>(assetPath);
        GameObject modelObject = new GameObject();
        modelObject.AddComponent<MeshFilter>();
        modelObject.AddComponent<MeshRenderer>();
        modelObject.GetComponent<MeshFilter>().mesh = mesh;
        modelObject.GetComponent<Renderer>().material.color =  new Color(1, 0, 0, 1);
        
        modelObject.AddComponent<prefabMovement>();
        BoxCollider boxCollider = modelObject.AddComponent<BoxCollider>();

        // Position the model in the Unity scene
        modelObject.transform.position = Vector3.zero;

    }
}
