using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class save : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveBuilding()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

            i++;
        }
        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        transform.gameObject.SetActive(true);

        // Get the MeshFilter component of the GameObject
        GameObject target = GameObject.Find("board");
        print(target);
        if (target == null)
        {
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
