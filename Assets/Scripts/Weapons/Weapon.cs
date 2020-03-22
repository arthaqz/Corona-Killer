using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Weapon : MonoBehaviour
    {
        public float offset;

        public GameObject projectile;

        public Transform shotPoint;
        
        public float timeBtwShots;
        public float startTimeBtwShots;

        public int maxAmmo;
        private int sumAmmo;
        public float reloadTime;
        private bool isReloading;

        private void Awake()
        {
            sumAmmo = maxAmmo;
            VeilMag.Instance.UpdateUI(maxAmmo, VeilMag.Operation.ADD);
        }

        public void Reload()
        {
            if (isReloading) return;
            if (sumAmmo == maxAmmo) return;

            
            StartCoroutine(ReloadingProcess());
        }

        private IEnumerator ReloadingProcess()
        {
            isReloading = true;
            AudioManager.Instance.Play("Reload Veil Gun");
            yield return new WaitForSeconds(reloadTime);
            var sumReloadAmmo = maxAmmo - sumAmmo;
            sumAmmo = maxAmmo;
            VeilMag.Instance.UpdateUI(sumReloadAmmo, VeilMag.Operation.ADD);
            isReloading = false;
        }

        public void Shoot()
        {
            if (timeBtwShots <= 0 && sumAmmo > 0)
            {
                Instantiate(projectile, shotPoint.position, transform.rotation, TempParent.Instance.transform);
                timeBtwShots = startTimeBtwShots;
                sumAmmo--;
                VeilMag.Instance.UpdateUI(1, VeilMag.Operation.SUBTRACT);
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        
    }
