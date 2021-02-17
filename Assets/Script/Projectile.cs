using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public Transform shootPoint;
    public GameObject cursor;
    public LayerMask layer;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;

    }

    private void Update()
    {
        LaunchProjectile();
    }

    void LaunchProjectile()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(camRay, out hit, 100f, layer))
        {
            cursor.SetActive(true);
            cursor.transform.position = hit.point + Vector3.up * 0.1f;

            Vector3 Vo = CalculateVelocity(hit.point, shootPoint.transform.position, 1f);

            transform.rotation = Quaternion.LookRotation(Vo);

            if(Input.GetMouseButtonDown(0))
            {
                Rigidbody obj = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
                obj.velocity = Vo;
            }
        }

        else
        {
            cursor.SetActive(false);
        }
    }



    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        float sY = distance.y;
        float sXZ = distanceXZ.magnitude;

        float vXZ = sXZ / time;
        float vY = sY / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= vXZ;
        result.y = vY;

        return result;
    }

}
