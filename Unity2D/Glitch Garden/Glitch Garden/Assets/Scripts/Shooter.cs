using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;

    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if(!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if(AttackerInLane())
        {
            //Debug.Log("Shoot pew pew");
            animator.SetBool("isAttacking", true);
        }
        else
        {
            //Debug.Log("Sit and wait");
            animator.SetBool("isAttacking", false);
        }        
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            //Debug.Log("spawner.transform.position.y = " + spawner.transform.position.y);
            //Debug.Log("transform.position.y = " + transform.position.y);

            bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;
            if(isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool AttackerInLane()
    {
        if(!myLaneSpawner) { return false; }

        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }        
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, 
                                                gun.transform.position, 
                                                transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
