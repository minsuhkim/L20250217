using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class World
    {
        public delegate int SortCompare(GameObject first, GameObject second);
        public SortCompare sortCompre;

        //DynamicArray 사용예정
        //public GameObject[] gameObjects = new GameObject[100];
        List<GameObject> gameObjects = new List<GameObject>();
        //int useGameObjectCount = 0;

        public List<GameObject> GetAllGameObjects
        {
            get
            {
                return gameObjects;
            }
        }
        public void Instantiate(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
            //gameObjects[useGameObjectCount] = gameObject;
            //useGameObjectCount++;
        }

        public void Update()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                foreach(Component component in gameObjects[i].components)
                {
                    component.Update();
                }
            }
        }

        public void Render()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                Renderer renderer = gameObjects[i].GetComponent<Renderer>();
                if(renderer != null)
                {
                    renderer.Render();
                    if(renderer is TextRenderer)
                    {
                        Console.WriteLine("textrenderer");
                    }
                }
            }
        }

        public void Sort()
        {
            //gameObjects.Sort();

            for (int i = 0; i < gameObjects.Count; i++)
            {
                for (int j = i + 1; j < gameObjects.Count; j++)
                {
                    //if (gameObjects[i].orderLayer - gameObjects[j].orderLayer > 0)
                    //{
                    //    GameObject temp = gameObjects[i];
                    //    gameObjects[i] = gameObjects[j];
                    //    gameObjects[j] = temp;
                    //}

                    if (sortCompre(gameObjects[i], gameObjects[j]) > 0)
                    {
                        GameObject temp = gameObjects[i];
                        gameObjects[i] = gameObjects[j];
                        gameObjects[j] = temp;
                    }
                }
            }


        }

        public void Awake()
        {
            foreach(var choiceObject in gameObjects)
            {
                foreach(Component component in choiceObject.components)
                {
                    component.Awake();
                }
            }
        }
    }
}
