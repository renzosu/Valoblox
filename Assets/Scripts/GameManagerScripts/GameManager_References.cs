using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class GameManager_References : MonoBehaviour
    {
        public string playerTag;
        public static string _playerTag;

        public string enemyTag;
        public static string _enemyTag;

        public static GameObject _player;

        void OnEnable()
        {
            _playerTag = playerTag;
            _enemyTag = enemyTag;

            _player = GameObject.FindGameObjectWithTag(_playerTag);
        }
        
    }
}

