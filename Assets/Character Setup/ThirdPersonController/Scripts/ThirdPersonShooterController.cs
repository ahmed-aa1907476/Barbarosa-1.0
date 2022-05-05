using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using TMPro;
public class ThirdPersonShooterController : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBulletPosition;
    public float bulletSpeed = 10;
    [SerializeField] private Transform VfxHitShoot;

    [SerializeField] private Transform muzzleFxPosition;
    [SerializeField] private Transform muzzleFx;
    private RaycastHit hit;
   // [SerializeField] private Transform spawnBulletPosition;
    
    public int ammo = 10;
    public TextMeshProUGUI Ammo;


    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;


    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
     if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
           // debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }
        else{    mouseWorldPosition = ray.GetPoint(10);}

        if (starterAssetsInputs.aim)
        {
        
            aimVirtualCamera.gameObject.SetActive(true);
           thirdPersonController.SetSensitivity(aimSensitivity); 
    
          thirdPersonController.setRotateOnMove(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else {
    
            aimVirtualCamera.gameObject.SetActive(false);
           thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.setRotateOnMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
        }

        if (starterAssetsInputs.shoot) {
            if (ammo > 0)
            { 
                Instantiate(muzzleFx, muzzleFxPosition.position, Quaternion.identity );
                
                if(hitTransform != null){
                   Debug.Log("Rayhit msg " + hitTransform.transform.name);
                    EnemyHealth enemy = hitTransform.transform.GetComponent<EnemyHealth>();
                    if(enemy != null )
                     enemy.takeDamage(20);
                    Instantiate(VfxHitShoot, hitTransform.position, Quaternion.identity);
                }
               // Vector3 aimDirection = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                //var bullet1 = Instantiate(bullet, spawnBulletPosition.position, Quaternion.LookRotation(aimDirection, Vector3.up));
               // bullet1.GetComponent<Rigidbody>().velocity = spawnBulletPosition.forward * bulletSpeed;
                starterAssetsInputs.shoot = false;
                ammo--;
                Ammo.text =  getAmmo().ToString();
            }
        }

    }
    public int getAmmo() {
        return ammo;
    }

    public void setAmmo(int newAmmo) {
        ammo += newAmmo;
    }



}
