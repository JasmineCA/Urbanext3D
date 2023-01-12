using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class slider : MonoBehaviour
{
    public Slider mainSlider;
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    public void ValueChangeCheck(float value)
    {
        GameObject target = GameObject.Find("model(Clone)");
        if(target != null){
            Vector3 scale = new Vector3(1, 1, 1);
            target.transform.localScale = value*scale;
        }
    }
}
