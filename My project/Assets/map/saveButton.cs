using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
	
using System.Collections;
using System.Collections.Generic;

public class saveButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {}

    public void Save()
    {
        // Get the MeshFilter component of the GameObject
        GameObject target = GameObject.Find("test");
        print(target);
        if (target == null){
            return;
        }

        MeshFilter mf = target.GetComponent<MeshFilter>();

        
        Mesh mesh = mf.sharedMesh;
        Mesh newMesh = new Mesh();

        //mesh.UploadMeshData(true);
        
        //Make a copy so it's not linked to the original mesh
        newMesh.vertices = mesh.vertices;
        newMesh.normals = mesh.normals;
        newMesh.triangles = mesh.triangles;
        newMesh.uv = mesh.uv;

        AssetDatabase.CreateAsset(newMesh, "Assets/NewAsset.asset");
        AssetDatabase.SaveAssets();
    }
}
