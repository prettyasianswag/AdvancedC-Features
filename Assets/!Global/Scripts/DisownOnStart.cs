using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GolfWithManny
{
    public class DisownOnStart : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            transform.SetParent(null);
        }
    }
}

