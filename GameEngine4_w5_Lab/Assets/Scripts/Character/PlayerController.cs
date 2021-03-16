using Character.UI;
using UnityEngine;
using Systems.Health;

namespace Character
{
  
    [RequireComponent(typeof(PlayerHealthComponent))]
    public class PlayerController : MonoBehaviour
    {
        
        public CrossHairScript CrossHair => CrossHairComponent;
        [SerializeField] private CrossHairScript CrossHairComponent;
        
        public bool IsFiring;
        public bool IsReloading;
        public bool IsJumping;
        public bool IsRunning;

    }
}
