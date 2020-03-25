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

        public Aiming aimingState;
        
        public Vector3 aimingUpRight = new Vector3(0,0,0);
        public Vector3 aimingUpLeft = new Vector3(0,0,0);
        public Vector3 aimingDownRight = new Vector3(0,0,180);
        public Vector3 aimingDownLeft = new Vector3(0,0,180);
        public Vector3 aimingLeft = new Vector3(0,0,90);
        public Vector3 aimingRight = new Vector3(0,0,-90);
        

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
        public void Aim(Aiming aimingType)
        {
            Vector3 rot;
            
            switch (aimingType)
            {
                case Aiming.UPRIGHT:
                    rot = aimingUpRight;
                    break;
                case Aiming.UPLEFT:
                    rot = aimingUpLeft;
                    break;
                case Aiming.DOWNRIGHT:
                    rot = aimingDownRight;
                    break;
                case Aiming.DOWNLEFT:
                    rot = aimingDownLeft;
                    break;
                case Aiming.LEFT:
                    rot = aimingLeft;
                    break;
                case Aiming.RIGHT:
                    rot = aimingRight;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(aimingType), aimingType, null);
            }

            transform.rotation =  Quaternion.Euler(rot);
            
        }

        public enum Aiming
        {
            UPRIGHT,
            UPLEFT,
            DOWNRIGHT,
            DOWNLEFT,
            LEFT,
            RIGHT
        }
    }
