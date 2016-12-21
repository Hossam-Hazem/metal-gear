using UnityEngine;
using System.Collections;

public class SpottingSnakeAttack : MonoBehaviour
{
    public GameObject bullet;
    public GameObject snake;
    int health = 100;

    void Start()
    {

    }

    void Update()
    {

        if (health > 0)
        {
            RaycastHit raycastHit;
            Vector3 origin = transform.position;
            if (Physics.SphereCast(origin, 0.5f, transform.forward, out raycastHit, 5, 1 << 8))
            {
                //transform.rotation = Quaternion.LookRotation(parentMainCamera.transform.forward);
                transform.LookAt(snake.transform);
                GameObject currentLocation = new GameObject();
                currentLocation.transform.position = transform.position;
                if (guardPath.destinationSnakeCurrentLocation != null)
                {
                    Destroy(guardPath.destinationSnakeCurrentLocation.gameObject);
                }
                guardPath.destinationSnakeCurrentLocation = currentLocation.transform;

                GameObject bulletClone = (GameObject)Instantiate(bullet, bullet.transform.position, bullet.transform.rotation);
                Rigidbody bulletCloneRigid = bulletClone.GetComponent<Rigidbody>();
                bulletCloneRigid.isKinematic = false;
                Vector3 dir = (snake.transform.position - this.transform.position).normalized;
                bulletCloneRigid.velocity = dir * 50f;
                bulletClone.SetActive(true);
            }
        }
    }
}
