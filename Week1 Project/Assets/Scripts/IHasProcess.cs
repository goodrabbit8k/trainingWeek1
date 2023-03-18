using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasProcess
{
    public event EventHandler<onProcessChangeEventArgs> onProcessChange;
 
    public class onProcessChangeEventArgs : EventArgs
    {
        public float processNormalized;
    }
}
