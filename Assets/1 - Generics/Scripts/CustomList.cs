﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generics
{
    [System.Serializable]
    public class CustomList<T>
    {
        public T[] list;

        public int capacity { get; }
        public int amount { get; private set; }
        public CustomList () { }
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
}
