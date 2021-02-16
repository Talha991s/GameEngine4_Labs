using UnityEngine;
using UnityEngine.InputSystem;
using Character.UI;
using System;


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
        private static readonly int AimHorizontalHash = Animator.StringToHash("AimHorizontal");
        private static readonly int AimVerticalHash = Animator.StringToHash("AimVertical");
        private static readonly int IsFiringHash = Animator.StringToHash("IsFiring");
        private static readonly int IsReloadingHash = Animator.StringToHash("IsReloading");
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
            if(spawnweapon)
            {
                WeaponComponent weapon = spawnweapon.GetComponent<WeaponComponent>();
                if(weapon)
                {
                    GripIKLocation = weapon.GripLocation;
                }
            }
        }

        private void OnAnimatorIK(int layerIndex)
        {
            PlayerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
            PlayerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, GripIKLocation.position);
        }
        public void OnReload(InputValue pressed)
        {
            Debug.Log("Reloading");

            PlayerAnimator.SetBool(IsReloadingHash, true);
        }
        public void OnFire(InputValue pressed)
        {
           // bool isFiring = pressed.ReadValue<float>() == 1.0f ? true : false;
            Debug.Log("Firing");
            PlayerAnimator.SetBool(IsFiringHash, true);
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
            Debug.Log(independentMousePosition);

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
