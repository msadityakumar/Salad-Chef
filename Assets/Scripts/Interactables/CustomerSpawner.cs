using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public Transform[] CustomerIndexes;
    public GameObject Customer;

    void Start()
    {
        SpawnCustomers();
    }

    public void SpawnCustomers()
    {
        for (int i = 0; i < CustomerIndexes.Length; i++)
        {
            SpawnCustomerAtIndex(i);
        }
    }

    void SpawnCustomerAtIndex(int index)
    {
        var customer = Instantiate(Customer, Vector3.zero, Quaternion.identity) as GameObject;
        customer.transform.parent = CustomerIndexes[index];
        customer.transform.localPosition = new Vector3(0f, 0f, 0f);
        var customerComp = customer.GetComponent<Customer>();
        customerComp.CustomerIndex = index;
        customerComp.CustSpawnerRef = this;
    }

    public void DestroyCustomerAtIndex(int index)
    {
        var custTransform = CustomerIndexes[index];
        var customer = custTransform.GetComponentInChildren<Customer>();
        Destroy(customer.gameObject);
        SpawnCustomerAtIndex(index);
    }
}
