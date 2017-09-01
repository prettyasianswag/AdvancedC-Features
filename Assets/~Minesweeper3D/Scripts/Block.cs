using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper3D
{
    [RequireComponent(typeof(Renderer))]
    public class Block : MonoBehaviour
    {
        [Header("Ints")]
        // Score X, Y and Z coordinate in array for later use
        public int x = 0;

        public int y = 0;

        public int z = 0;

        [Header("Bools")]
        // Is the block a mine?
        public bool isMine = false;

        // Has the block been revealed?
        private bool isRevealed = false;

        [Header("References")]
        // Array for text colours
        public Color[] textColors;

        // Reference to the text element
        public TextMesh textElement;

        // Reference to the mine
        public Transform mine;

        // Reference to the renderer
        private Renderer rend;

        void Awake()
        {
            // Grab the reference to the renderer
            rend = GetComponent<Renderer>();
        }

        void Start()
        {
            // Detach Text Element from block
            textElement.transform.SetParent(null);

            // Randomly decide if it's a mine or not
            isMine = Random.value < 0.5f;
        }


        void Update()
        {
            // If player left clicks, deactivates the block
            if (Input.GetMouseButtonDown(0))
            {
                DeactvateBlock();
            }
        }

        // Determining which index of colours to use for which number we have
        void UpdateText (int adjacentMines)
        {
            // Are there adjacent mines?
            if (adjacentMines > 0)
            {
                // Set text to amount of mines
                textElement.text = adjacentMines.ToString();

                // Check if adjacentMines are within textColour's array
                if (adjacentMines >= 0 && adjacentMines < textColors.Length)
                {
                    // Set text color to whatever was preset
                    textElement.color = textColors[adjacentMines];
                }
            }
        }

        public void Reveal (int adjacentMines)
        {
            // Flags the block as being revealed
            isRevealed = true;
            
            // Checks if block is a mine
            if (isMine)
            {
                // Activate the references mine
                mine.gameObject.SetActive(true);

                // Detach mine from children
                mine.SetParent(null);
            }
            else
            {
                // Updates the text to display adjacentMines
                UpdateText(adjacentMines);
            }
            // Deactivates the block
            gameObject.SetActive(false);
        }

        // Deactivate Block
        void DeactvateBlock()
        {
            // Getting mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Hit for raycast
            RaycastHit hit;

            // If the raycast hits, set the gameobject to false
            if (Physics.Raycast(ray, out hit))
            {
                gameObject.SetActive(false);
            }
        }
    }
}

