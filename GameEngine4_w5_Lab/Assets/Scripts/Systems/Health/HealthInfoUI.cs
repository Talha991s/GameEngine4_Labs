using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Systems.Health;

namespace UI.Player_UI
{


    public class HealthInfoUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text HealthText;
        private HealthComponent playerHealthComponent;


        private void OnEnable()
        {
            PlayerEvents.OnHealthinitialized += OnHealthInitialized;
        }
        private void OnDisable()
        {
            PlayerEvents.OnHealthinitialized -= OnHealthInitialized;
        }
        private void OnHealthInitialized(HealthComponent healthcomponent)
        {
            playerHealthComponent = healthcomponent;
        }

        // Update is called once per frame
        void Update()
        {
            HealthText.text = playerHealthComponent.Health.ToString();
        }
    }
}