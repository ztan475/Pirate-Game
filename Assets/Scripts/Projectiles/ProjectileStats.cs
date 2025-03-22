using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile Stats")]
public class ProjectileStats : ScriptableObject
{
    public float projectileVelocity;
    public int damage;
    public GameObject projectileOnHit;
    public float radius;
    public LayerMask targetLayer;
}
