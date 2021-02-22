using UnityEngine;
using UnityEngine.InputSystem;
using Character;
using System;
using Weapon;
using Character.UI;


namespace Character
{

    public class WeaponHolder : MonoBehaviour
    {
        [Header("Weapon to Spawn"), SerializeField]
        private GameObject weaponToSpawn;

        [SerializeField] private Transform weaponSocketLocation;

        private Transform GripIKLocation;

        //compnents
        private PlayerController PlayerController;
        private Crosshair PlayerCrosshair;
        private Animator PlayerAnimator;

        //Ref
        private Camera viewCamera;
        private WeaponComponent EquippedWeapon;
        private readonly int AimHorizontalHash = Animator.StringToHash("AimHorizontal");
        private readonly int AimVerticalHash = Animator.StringToHash("AimVertical");
        private readonly int IsFiringHash = Animator.StringToHash("IsFiring");
        private readonly int IsReloadingHash = Animator.StringToHash("IsReloading");
        private void Awake()
        {
            // base.Awake();
            PlayerAnimator = GetComponent<Animator>();

            PlayerController = GetComponent<PlayerController>();
            if (PlayerController)
            {
                PlayerCrosshair = PlayerController.Crosshair;
            }
            viewCamera = Camera.main;
        }

        // Start is called before the first frame update
        void Start()
        {
            GameObject spawnweapon = Instantiate(weaponToSpawn, weaponSocketLocation.position, weaponSocketLocation.rotation, weaponSocketLocation);
            if (!spawnweapon) return;

            spawnweapon.transform.parent = weaponSocketLocation;
            EquippedWeapon = spawnweapon.GetComponent<WeaponComponent>();
            GripIKLocation = EquippedWeapon.GripLocation;
            EquippedWeapon.Initialize(this, PlayerController.Crosshair);
            //WeaponComponent weapon = spawnweapon.GetComponent<WeaponComponent>();
            //if (weapon)
            //{
            //    GripIKLocation = weapon.GripLocation;
            //}
            //weapon.Initialize(this, PlayerController.Crosshair);

        }

        private void OnAnimatorIK(int layerIndex)
        {
            PlayerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
            PlayerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, GripIKLocation.position);
        }
        public void OnReload(InputValue pressed)
        {
            // Debug.Log("Reloading");
            StartReloading();

        }
        public void StartReloading()
        {
            PlayerController.IsReloading = true;
            PlayerAnimator.SetBool(IsReloadingHash, true);
            EquippedWeapon.StartReloading();

            InvokeRepeating(nameof(StopReloading), 0.0f, 0.1f);
        }
        public void StopReloading()
        {
            if (PlayerAnimator.GetBool(IsReloadingHash)) return;

            PlayerController.IsReloading = false;
            EquippedWeapon.StopReloading();

            CancelInvoke(nameof(StopReloading));
        }
        public void OnFire(InputValue pressed)
        {
            // bool isFiring = pressed.ReadValue<float>() == 1.0f ? true : false;
           // Debug.Log("Firing");
            // PlayerAnimator.SetBool(IsFiringHash, true);
            if (pressed.isPressed)
            {
                PlayerController.IsFiring = true;
                PlayerAnimator.SetBool(IsFiringHash, true);
                EquippedWeapon.StartFiring();
            }
            else
            {
                PlayerController.IsFiring = false;
                PlayerAnimator.SetBool(IsFiringHash, false);
                EquippedWeapon.StopFiring();
            }
            //if(PlayerController.IsFiring == true)
            //{
            //    PlayerAnimator.SetBool(IsFiringHash, true);
            //}
            //else
            //{
            //    PlayerAnimator.SetBool(IsFiringHash, false);
            //}
        }

        public void OnLook(InputValue obj)
        {
            Vector3 independentMousePosition = viewCamera.ScreenToViewportPoint(PlayerController.Crosshair.CurrentAimPosition);
            //Vector3 independentMousePosition = viewCamera.ScreenToViewportPoint(PlayerCrosshair.CurrentAimPosition);
            //Debug.Log(independentMousePosition);

            PlayerAnimator.SetFloat(AimHorizontalHash, independentMousePosition.x);
            PlayerAnimator.SetFloat(AimVerticalHash, independentMousePosition.y);
        }

        //private new void OnEnable()
        //{
        //    base.OnEnable();
        //    //GameInput.PlayerActionMap.Look.performed += OnLook;
        //    GameInput.PlayerActionMap.Look.performed += OnLook;
        //}
        //private new void OnDisable()
        //{
        //    base.OnDisable();
        //    GameInput.PlayerActionMap.Look.performed -= OnLook;
        //}
    }

}
