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

        //compnents
        private PlayerController PlayerController;
        private Crosshair PlayerCrosshair;
        private Animator PlayerAnimator;

        //Ref
        private Camera viewCamera;

        private void Awake()
        {

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

        }
        public void OnLook(InputValue delta)
        {
            Vector2 independentMousePosition = viewCamera.ScreenToViewportPoint(PlayerCrosshair.CurrentAimPosition);
           // Vector3 independentMousePosition = viewCamera.ScreenToViewportPoint(PlayerCrosshair.CurrentAimPosition);
            Debug.Log(independentMousePosition);
        }

        //private void //OnEnable()
        //{
        //    base.OnEnable();
        //    GameInput.PlayerActionMap.Look.performed += OnLook;
        //}


        //private void OnDisable()
        //{
        //    base.OnDisable();
        //    GameInput.PlayerActionMap.Look.performed -= OnLook;
        //}
    }
}