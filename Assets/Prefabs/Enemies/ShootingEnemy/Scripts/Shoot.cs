using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingEnemy
{
  public class Shoot : MonoBehaviour
  {

    public float fireRate = 1f;
    public float nextShot = 0f;

    public Transform shootingPoint;
    private GameObject player;
    private Vector3 playerPosition;
    public GameObject projectile;
    public List<GameObject> projectilePool;

    private void Awake()
    {
      projectilePool = new List<GameObject>();
      CreateProjectilePool();
    }

    private void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
      playerPosition = player.transform.position;
      transform.right = playerPosition - transform.position;

      if (Time.time > nextShot)
      {
        Fire();
      }
    }

    private void CreateProjectilePool()
    {
      for (int i = 0; i < 5; i++)
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
          Debug.Log(projectilePool[i].name);
          return projectilePool[i];
        }
      }

      return null;
    }
  }
}
