using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class button : MonoBehaviour
{
    public GameObject modelObject;
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    public void LoadModel()
    {
        // Open file dialog to select model
        string modelPath = "Assets\\map\\model.fbx";
        Destroy(modelObject);
        File.Delete(modelPath);
        UnityEditor.AssetDatabase.Refresh();

        string realModelPath = EditorUtility.OpenFilePanel("Select Model", "", "fbx");
        FileUtil.CopyFileOrDirectory(realModelPath, modelPath);
        
        if (modelPath.Length == 0) return; // if user click cancel return

        // Load the selected model as an asset
        UnityEditor.AssetDatabase.Refresh();
        var modelAsset = AssetDatabase.LoadAssetAtPath(modelPath, typeof(GameObject));
        // Instantiate the model asset
        modelObject = Instantiate(modelAsset) as GameObject;

        // Position the model in the Unity scene
        modelObject.transform.position = Vector3.zero;

    }
}