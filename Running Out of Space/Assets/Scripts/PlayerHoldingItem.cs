using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldingItem : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    private Grabbable objectGrabbable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null)
            {
                // Not carring an object, try to grab
                float pickUpDistance = 2f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                {
                    //Debug.Log(Raycast.transform);
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                    }
                    if (raycastHit.transform.TryGetComponent(out FirstMessage message))
                    {
                        message.DisplayMessage();
                    }
                }
            }
            else
            {
                //Currently carrying an object, drop
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
        if (objectGrabbable != null && Input.GetMouseButtonDown(0))
        {
            objectGrabbable.Throw();
            objectGrabbable = null;
        }
    }
}
