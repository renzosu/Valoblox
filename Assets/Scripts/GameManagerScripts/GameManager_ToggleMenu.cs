using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class GameManager_ToggleMenu : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;
        public GameObject menu;

        // Start is called before the first frame update
        void Start()
        {
            ToggleMenu();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForMenuToggleRequest();
        }

        void OnEnable()
        {
            SetInitialReferences();
            gameManagerMaster.GameOverEvent += ToggleMenu;
        }

        void OnDisable()
        {
            gameManagerMaster.GameOverEvent -= ToggleMenu;
        }

        void SetInitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }

        void CheckForMenuToggleRequest()
        {
            if (Input.GetKeyUp(KeyCode.Escape) && !gameManagerMaster.isGameOver && !gameManagerMaster.isInventoryUIOn)
            {
                ToggleMenu();
            }
        }

        void ToggleMenu()
        {
            if (menu != null) 
            {
                menu.SetActive(!menu.activeSelf);
                gameManagerMaster.isMenuOn = !gameManagerMaster.isMenuOn;
                gameManagerMaster.CallEventMenuToggle();
            }
            else 
            {
                Debug.LogWarning("You need to assign a UI GameObject to the Toggle Menu script in the inspector");
            }
        }
    }
}
