using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public RectTransform BarRectTransform;
    float m_BarDisplay; //current progress
    private Customer m_Customer;

    void Start()
    {
        m_Customer = GetComponent<Customer>();
    }

    void Update()
    {
        BarRectTransform.localScale = new Vector3(m_Customer.GetProgress(), BarRectTransform.localScale.y, BarRectTransform.localScale.z); 
    }
}
