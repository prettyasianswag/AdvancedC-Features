﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generics
{

    public class GenericsTest : MonoBehaviour
    {
        public CustomList<GameObject> gameObjects;
        public CarBrands<GameObject> cars;

        // Use this for initialization
        void Start()
        {
            // Add
            gameObjects = new CustomList<GameObject>();
            gameObjects.Add(new GameObject());
            gameObjects.Add(new GameObject());
            gameObjects.Add(new GameObject());

            GameObject firstObject = gameObjects[0];

            // Add Range
            CarBrands<GameObject> carList1 = new CarBrands<GameObject>();
            //carList1.Add(car1);

            CarBrands<GameObject> carList2 = new CarBrands<GameObject>();

            //CarBrands.RemoveAt(car1);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
