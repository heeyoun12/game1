using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField]
    private Gun currentGun;

    private float currentFireRate;

    private bool isReload = false;
    public bool isFineSightMode = false;

    // 본래 포지션 값.
    [SerializeField]
    private Vector3 originPos;

    private AudioSource audioSource;
    private RaycastHit hitInfo;
    public Camera camera;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GunFireRateCalc();
        TryFire();
        TryReload();
    }

    private void GunFireRateCalc()
    {
        if (currentFireRate > 0)
            currentFireRate -= Time.deltaTime;
    }

    private void TryFire()
    {
        if (Input.GetButton("Fire1") && currentFireRate <= 0 && !isReload)
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (!isReload)
        {
            if (currentGun.currentBulletCount > 0)
                Shoot();
        }
    }

    private void Shoot()
    {
        currentGun.currentBulletCount--;
        currentFireRate = currentGun.fireRate; // 연사 속도 재계산.
        PlaySE(currentGun.fire_Sound);
        currentGun.muzzleFlash.Play();
        Hit();
        Debug.Log("총알 발사함");

    }

    public void Hit()
    {
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, currentGun.range))
        {
            if(hitInfo.transform.tag == "Enemy")
            {
                hitInfo.transform.GetComponent<ZombieMoving>.damage
            }
        }
    }

    private void TryReload()
    {
        if (currentGun.currentBulletCount == 0)
        {

        }
    }





    private void PlaySE(AudioClip _clip)
    {
        audioSource.clip = _clip;
        audioSource.Play();
    }
}
