using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stalker
{
  public class Shoot : MonoBehaviour
  {

    public float fireRate = 1f;
    public float nextShot = 0f;
    private bool wait = true;

    public Transform shootingPoint;
    private PlayerMovement playerMovement;
    private Vector3 playerDestination;
    public GameObject projectile;
    public List<GameObject> projectilePool;

    private void Awake()
    {
      projectilePool = new List<GameObject>();
      CreateProjectilePool();
    }

    private void Start()
    {
      playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
      playerDestination = playerMovement.playerDestination;
      transform.right = playerDestination - transform.position;

      if (Time.time > nextShot && !wait)
      {
        Fire();
      }
    }

    private void CreateProjectilePool()
    {
      for (int i = 0; i < 3; i++)
      {
        GameObject clone = Instantiate(projectile);
        clone.name = clone.name + i;
        clone.SetActive(false);
        projectilePool.Add(clone);
      }
    }

    private void Fire()
    {
      GameObject projectile = GetPooledObject();

      if (projectile == null)
      {
        return;
      }
      projectile.transform.position = shootingPoint.position;
      projectile.transform.rotation = transform.rotation;
      projectile.SetActive(true);
      nextShot = Time.time + fireRate;
    }

    private GameObject GetPooledObject()
    {
      for (int i = 0; i < projectilePool.Count; i++)
      {
        if (!projectilePool[i].activeInHierarchy)
        {
          return projectilePool[i];
        }
      }

      return null;
    }

    public void StartShooting()
    {
      StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
      yield return new WaitForSeconds(0.5f);
      wait = false;
    }
  }
}