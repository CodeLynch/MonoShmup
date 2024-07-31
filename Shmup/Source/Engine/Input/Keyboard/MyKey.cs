using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class MyKey
    {
        public int state;
        public string key, print, display;

        public MyKey(string key, int state)
        {
            this.key = key;
            this.state = state;
        }

        public virtual void Update()
        {
            state = 2;
            MakePrint(key);
        }

        public void MakePrint(string KEY)
        {
            display = KEY;

            string tempStr = "";

            if (KEY.Length == 1 && (KEY[0] >= 'A' && KEY[0] <= 'Z'))
            {
                tempStr = KEY;
                Debug.WriteLine("youre pressing a key!");
            }
            if (KEY == "Space")
            {
                tempStr = " ";
            }
            if (KEY == "OemCloseBrackets")
            {
                tempStr = "]";
                display = tempStr;
            }
            if (KEY == "OemOpenBrackets")
            {
                tempStr = "[";
                display = tempStr;
            }
            if (KEY == "OemMinus")
            {
                tempStr = "-";
                display = tempStr;
            }
            if (KEY == "OemPeriod" || KEY == "Decimal")
            {
                tempStr = ".";
            }
            if (KEY == "D1" || KEY == "D2" || KEY == "D3" || KEY == "D4" || KEY == "D5" || KEY == "D6" || KEY == "D7" || KEY == "D8" || KEY == "D9" || KEY == "D0")
            {
                tempStr = KEY.Substring(1);
            }
            else if (KEY == "NumPad1" || KEY == "NumPad2" || KEY == "NumPad3" || KEY == "NumPad4" || KEY == "NumPad5" || KEY == "NumPad6" || KEY == "NumPad7" || KEY == "NumPad8" || KEY == "NumPad9" || KEY == "NumPad0")
            {
                tempStr = KEY.Substring(6);
            }


            print = tempStr;
        }
    }
}
