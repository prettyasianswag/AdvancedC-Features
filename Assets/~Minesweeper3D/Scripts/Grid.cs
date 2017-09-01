using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper3D
{
    public class Grid : MonoBehaviour
    {
        public GameObject blockPrefab;

        // The grid's dimensions
        public int width = 10;
        public int height = 10;
        public int depth = 10;

        // How much spacing between each Block
        public float spacing = 1.2f;

        // Multi-Dimensional Array storing the blocks (in this case 3D)
        private Block[,,] blocks;

        void Start()
        {
            // Generate blocks on startup
            GenerateBlocks();
        }

        void Update()
        {

        }

        // Spawns a block at position and returns the block component
        Block SpawnBlock(Vector3 pos)
        {
            // Instantiate the clone
            GameObject clone = Instantiate(blockPrefab);

            // Setting the position of the clone
            clone.transform.position = pos;

            // Get Block Component
            Block currentBlock = clone.GetComponent<Block>();

            // Return
            return currentBlock;
        }

        // Spawns block in a grid-like fashion
        void GenerateBlocks()
        {
            // Create 3D array to store all the blocks
            blocks = new Block[width, height, depth];

            // Loop through the X, Y, Z axis of the 3D array
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int z = 0; z < depth; z++)
                    {
                        // Calculate half size using arrray dimensions
                        Vector3 halfSize = new Vector3(width / 2, height / 2, depth / 2);

                        // Make sure to offset by half (so that elements are centered)
                        halfSize -= new Vector3(0.5f, 0.5f, 0.5f);

                        // Create position for element to pivot around Grid zero
                        Vector3 pos = new Vector3(x - halfSize.x, y - halfSize.y, z - halfSize.z);

                        // Apply Spacing (pos = pos * spacing)
                        pos *= spacing;

                        // Spawn the block at that position
                        Block block = SpawnBlock(pos);

                        // Attach block to grid as a child
                        block.transform.SetParent(transform);

                        // Store array coordinate inside the block itself
                        block.x = x;
                        block.y = y;
                        block.z = z;

                        // Store block in the array at coordinates
                        blocks[x, y, z] = block;
                    }
                }
            }
        }

        public void GetAdjacentMineCountAt(Block b)
        {
            // Loop through all elements and have each axis go between -1 to 1
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    for (int z = -1; z <= -1; z++)
                    {
                        // Calculate adjacent element's index
                        int desiredX = b.x + x;

                        int desiredY = b.y + y;

                        int desiredZ = b.z + z;

                        // IF desiredX is within range of blocks array
                        if (desiredX == b.x)
                        {
                            // IF the element at index is a mine
                            if (b.isMine)
                            {
                                // Increment count by 1
                                desiredX++;
                            }
                        }

                        if (desiredY == b.y)
                        {
                            // IF the element at index is a mine
                            if (b.isMine)
                            {
                                // Increment count by 1
                                desiredY++;
                            }
                        }
                        
                        if (desiredZ == b.z)
                        {
                            // IF the element at index is a mine
                            if (b.isMine)
                            {
                                // Increment count by 1
                                desiredZ++;
                            }
                        }
                    }
                }
            }
        }
    }
}
