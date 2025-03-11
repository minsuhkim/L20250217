﻿using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class GameObject
    {
        public List<Component> components = new List<Component>();


        public bool isTrigger = false;
        public bool isCollide = false;

        public string name;
        protected static int gameObjectCount = 0;

        public Transform transform;

        public GameObject()
        {
            Init();
            gameObjectCount++;
            name = $"GameObject ({gameObjectCount})";
        }

        ~GameObject()
        {
            gameObjectCount--;
        }

        public void Init()
        {
            transform = new Transform();
            AddComponent<Transform>();
        }

        public T AddComponent<T>(T inComponent) where T : Component
        {

            components.Add(inComponent);
            inComponent.gameObject = this;
            inComponent.transform = transform;

            return inComponent;
        }

        public T AddComponent<T>() where T : Component, new()
        {
            T inComponent = new T();
            AddComponent<T>(inComponent);

            return inComponent;
        }

        public virtual void Update()
        {

        }

        public bool PredictCollision(int newX, int newY)
        {
            //for (int i = 0; i < Engine.Instance.world.GetAllGameObjects.Count; i++)
            //{
            //    if (Engine.Instance.world.GetAllGameObjects[i].isCollide == true &&
            //            Engine.Instance.world.GetAllGameObjects[i].X == newX &&
            //            Engine.Instance.world.GetAllGameObjects[i].Y == newY)
            //    {
            //        return true;
            //    }
            //}
            return false;
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in components)
            {
                if (component is T)
                {
                    return (T)component;
                }
            }

            return null;
        }

        public void ExecuteMethod(string methodName, Object[] parameters)
        {
            foreach (var component in components)
            {
                Type type = component.GetType();
                MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (var info in methodInfos)
                {
                    if (info.Name.CompareTo(methodName) == 0)
                    {
                        info.Invoke(component, parameters);
                    }
                }
            }
        }
    }
}
