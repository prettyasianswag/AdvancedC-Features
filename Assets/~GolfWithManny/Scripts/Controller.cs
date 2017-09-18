using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace GolfWithManny
{
    [RequireComponent(typeof(Player))]
    public class Controller : NetworkBehaviour
    {
        public Camera cam;
        private Player p;

        void Start()
        {
            p = GetComponent<Player>();
            if (!isLocalPlayer)
            {
                cam.gameObject.SetActive(false);
            }
        }

        void Update()
        {
            if (isLocalPlayer)
            {
                Vector3 camForward = cam.transform.forward;

                if (Input.GetKeyDown(KeyCode.W))
                {
                    p.Move(camForward);
                }
            }
        }
    }
}

