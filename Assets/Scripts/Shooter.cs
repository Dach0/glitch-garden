using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile = default, gun = default;

   public void Fire()
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
    }
}
