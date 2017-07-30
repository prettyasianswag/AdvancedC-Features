using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generics
{
    [System.Serializable]
    public class CustomList<T>
    {
        public T[] list;

        //public int capacity { get; }
        public int amount { get; private set; }
        public CustomList() { }
        // gameObjects[0]
        public T this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }

        public void Add(T item)
        {
            // Create a new array of amount + 1
            T[] cache = new T[amount + 1];
            // Check if list has been initialized
            if (list != null)
            {
                // Copy all existing items to new array
                for (int i = 0; i < list.Length; i++)
                {
                    cache[i] = list[i];
                }
            }
            // Place new item at end index
            cache[amount] = item;
            // Replace old array with new array
            list = cache;
            // Increment amount
            amount++;
        }
    }

    public class CarBrands<C>
    {
        // Getting and setting the stats for the items
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Cost { get; set; }
        public string Type { get; set; }

        public void CarDealership()
        {
            // Creating Items for each of the 2 lists
            CarBrands<GameObject> car1 = new CarBrands<GameObject>()
            {
                Brand = "Ferrari",
                Model = "458Italia",
                Cost = 600000,
                Type = "ExoticCar"
            };
            CarBrands<GameObject> car2 = new CarBrands<GameObject>()
            {
                Brand = "Lamborghini",
                Model = "Murcielago",
                Cost = 450000,
                Type = "ExoticCar"
            };
            CarBrands<GameObject> car3 = new CarBrands<GameObject>()
            {
                Brand = "Ford",
                Model = "GT",
                Cost = 397500,
                Type = "ExoticCar"
            };
            CarBrands<GameObject> car4 = new CarBrands<GameObject>()
            {
                Brand = "Bugatti",
                Model = "Veyron",
                Cost = 1500000,
                Type = "SuperCar"
            };
            CarBrands<GameObject> car5 = new CarBrands<GameObject>()
            {
                Brand = "McLaren",
                Model = "P1GTR",
                Cost = 2000000,
                Type = "SuperCar"
            };
        }
    }
}
