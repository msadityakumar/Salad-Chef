using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour
{
    public RectTransform BarRectTransform;
    float m_BarDisplay; //current progress

    void Update()
    {
        var customer = this.GetComponent<Customer>();
        BarRectTransform.localScale = new Vector3(customer.GetProgress(), BarRectTransform.localScale.y, BarRectTransform.localScale.z); 
    }
}
