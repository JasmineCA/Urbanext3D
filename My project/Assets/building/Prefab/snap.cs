using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        bool isSelected = this.transform.parent.GetComponent<Target>().getIsSelected();
        if (isSelected && this.CompareTag("snappoint") && other.CompareTag("snappoint"))
        {
            this.transform.parent.GetComponent<Target>().setEnableDrag(false);
            this.transform.parent.position += other.transform.position - this.transform.position;
        }
    }
}
