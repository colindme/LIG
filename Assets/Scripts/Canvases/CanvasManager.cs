using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Canvas
{
    public class CanvasManager : MonoBehaviour
    {
        private static CanvasManager _instance = null;
        private CanvasBase _currentlyOpenCanvas = null;

        public static CanvasManager Instance { get => _instance; }
        public CanvasBase CurrentlyOpenCanvas { get => _currentlyOpenCanvas; }
        

        public void Awake()
        {
            if (_instance != null && this != _instance)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

    }
}