using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public float DetectionRange;
    public LayerMask itemLayerMask;
    public KeyCode ItemCollectionKey;
    public InventorySystem InventorySystems;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectItems();
    }

    void DetectItems()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.forward);
        if (Physics.Raycast(ray, out hit, DetectionRange, itemLayerMask))
        {
            Debug.Log("ItemDetected: " + hit.collider.gameObject.name);
        }
        if (Input.GetKeyDown(ItemCollectionKey))
        {
            hit.collider.gameObject.GetComponent<CollectibleItem>().CollectItem();
        }
    }

    public void CollectItem(Items item)
    {
        InventorySystems.AddItem(item);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.forward * DetectionRange);
    }
}
