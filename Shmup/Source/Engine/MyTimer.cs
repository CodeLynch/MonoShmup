using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Shmup;

namespace Shmup
{
    public class MyTimer
    {
        public bool flag;
        protected int mSec;
        protected TimeSpan timer = new TimeSpan();


        public MyTimer(int m)
        {
            flag = false;
            mSec = m;
        }
        public MyTimer(int m, bool flagval)
        {
            flag = flagval;
            mSec = m;
        }

        public int MSec
        {
            get { return mSec; }
            set { mSec = value; }
        }
        public int Timer
        {
            get { return (int)timer.TotalMilliseconds; }
        }



        public void UpdateTimer()
        {
            timer += Globals.gameTime.ElapsedGameTime;
        }

        public void ModifiedUpdateTimer(float speed)
        {
            timer += TimeSpan.FromTicks((long)(Globals.gameTime.ElapsedGameTime.Ticks * speed));
        }

        public virtual void AddToTimer(int msec)
        {
            timer += TimeSpan.FromMilliseconds((long)(msec));
        }

        public bool isReady()
        {
            if (timer.TotalMilliseconds >= mSec || flag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            timer = timer.Subtract(new TimeSpan(0, 0, mSec / 60000, mSec / 1000, mSec % 1000));
            if (timer.TotalMilliseconds < 0)
            {
                timer = TimeSpan.Zero;
            }
            flag = false;
        }

        public void Reset(int newTime)
        {
            timer = TimeSpan.Zero;
            MSec = newTime;
            flag = false;
        }

        public void ResetToZero()
        {
            timer = TimeSpan.Zero;
            flag = false;
        }

        public virtual XElement ReturnXML()
        {
            XElement xml = new XElement("Timer",
                                    new XElement("mSec", mSec),
                                    new XElement("timer", Timer));



            return xml;
        }

        public void SetTimer(TimeSpan time)
        {
            timer = time;
        }

        public virtual void SetTimer(int msec)
        {
            timer = TimeSpan.FromMilliseconds((long)(msec));
        }
    }
}

