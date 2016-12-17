using UnityEngine;
using System.Collections;

public class SpottingSnakeLose : MonoBehaviour {

    void Update()
    {
        RaycastHit raycastHit;
        Vector3 origin = transform.position;
        if (Physics.SphereCast(origin, 0.5f, transform.forward, out raycastHit, 5, 1 << 8))
        {
            //show loosing menu
        }
    }
}
