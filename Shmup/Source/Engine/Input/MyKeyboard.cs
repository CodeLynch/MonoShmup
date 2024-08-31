using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class MyKeyboard
    {
        public KeyboardState newKB, oldKB;
        public List<MyKey> pressedKeys = new List<MyKey>(), prevPressedKeys = new List<MyKey>();

        public MyKeyboard() { }

        public virtual void Update() { 
            newKB = Keyboard.GetState();
            GetPressedKeys();
        }

        public void UpdateOld()
        {
            oldKB = newKB;
            prevPressedKeys = new List<MyKey>();
            for (int i = 0; i < pressedKeys.Count; i++)
            {
                prevPressedKeys.Add(pressedKeys[i]);
            }
        }

        public bool GetPress(string key)
        {
            
            for (int i = 0; i < pressedKeys.Count; i++) {
                if (pressedKeys[i].key == key)
                {
                    return true;
                }
            }
            return false;
        }

        public virtual void GetPressedKeys()
        {
            bool found = false;
            pressedKeys.Clear();
            for(int i = 0; i < newKB.GetPressedKeys().Length; i++)
            {
                pressedKeys.Add(new MyKey(newKB.GetPressedKeys()[i].ToString(), 1));
            }
        }

        public bool GetSinglepress(string key)
        {
            for (int i = 0; i < pressedKeys.Count; i++)
            {
                bool isIn = false;

                for (int j = 0; j < prevPressedKeys.Count; j++)
                {
                    if (pressedKeys[i].key == prevPressedKeys[j].key)
                    {
                        isIn = true;
                        break;
                    }
                }
                if(!isIn && (pressedKeys[i].key == key || pressedKeys[i].print == key))
                {
                    return true;
                }
            }

            return false;

        }
    }
}
