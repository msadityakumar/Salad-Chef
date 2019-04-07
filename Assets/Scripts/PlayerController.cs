using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;

    [SerializeField] private string InputHorizontalAxis;
    [SerializeField] private string InputVerticalAxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis(InputHorizontalAxis);
        float yAxis = Input.GetAxis(InputVerticalAxis);

        Vector3 movement = new Vector3(xAxis * Time.deltaTime * Speed, yAxis * Time.deltaTime * Speed, 0f);
        this.gameObject.transform.Translate(movement);
    }
}
