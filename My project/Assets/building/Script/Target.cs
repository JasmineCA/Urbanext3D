using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private bool isSelected = false;
    private bool enableDrag;
    public float DelayTimer = 0.5f;
    private Renderer renderer;
    private float timestamp;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getIsSelected()
    {
        return (this.isSelected);
    }

    public bool getEnableDrag()
    {
        return (this.enableDrag);
    }

    public void setEnableDrag(bool value)
    {
        this.enableDrag = value;
    }

    private void OnMouseEnter()
    {
        if (board_logic.menuHidden)
        {
            renderer.material.color = Color.red;
            this.isSelected = true;
            this.enableDrag = true;
        }
    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
        this.isSelected = false;
    }

    private void OnMouseOver()
    {
        if (board_logic.menuHidden)
        {
            if (Input.GetKey(KeyCode.R) && Time.time > timestamp)
            {
                transform.Rotate(new Vector3(0, 90, 0));
                timestamp = Time.time + DelayTimer;
            }

            if (Input.GetKey(KeyCode.Delete) && Time.time > timestamp)
            {
                Destroy(gameObject);
            }
        }
            
    }

}
