using UnityEngine;
using System.Collections;

public class SpottingSnakeAttack : MonoBehaviour {

    void Start()
    {

    }

    void Update()
    {
        RaycastHit raycastHit;
        Vector3 origin = transform.position;
        if (Physics.SphereCast(origin, 0.5f, transform.forward, out raycastHit, 5, 1 << 8))
        {
            //raycastHit.transform;
            GameObject currentLocation = new GameObject();
            currentLocation.transform.position = transform.position;
            if (guardPath.destinationSnakeCurrentLocation != null)
            {
                Destroy(guardPath.destinationSnakeCurrentLocation.gameObject);
            }
            guardPath.destinationSnakeCurrentLocation = currentLocation.transform;

        }
    }
}
