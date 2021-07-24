using System.Collections;
using UnityEngine;

namespace S3
{
    public class GameManager_ToggleInventoryUI : MonoBehaviour
    {
        [Tooltip("Does this gamemode have an inventory?")]
        public bool hasInventory;
        public GameObject inventoryUI;
        public string toggleInventoryButton;
        private GameManager_Master gameManagerMaster;

        // Start is called before the first frame update
        void Start()
        {
            SetInitialReferences();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForInventoryUIToggleRequest();
        }

        void SetInitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();

            if (toggleInventoryButton == "") 
            {
                Debug.LogWarning("Please type in name of button used to toggle inventory in GameManager_ToggleInventoryUI");
                this.enabled = false;
            }

        }

        void CheckForInventoryUIToggleRequest()
        {
            if (Input.GetKeyDown(KeyCode.Tab) && !gameManagerMaster.isMenuOn && !gameManagerMaster.isGameOver && hasInventory)
            {
                ToggleInventoryUI();
            }
        }

        void ToggleInventoryUI()
        {
            if (inventoryUI != null)
            {
                inventoryUI.SetActive(!inventoryUI.activeSelf);
                gameManagerMaster.isInventoryUIOn = !gameManagerMaster.isInventoryUIOn;
                gameManagerMaster.CallEventInventoryUIToggle();
            }
        }
    }
}

