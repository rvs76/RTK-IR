﻿using ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static void InvokeIfRequired<T>(this T c, Action<T> action) 
            where T : Control
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new Action(() => action(c)));
            }
            else
            {
                action(c);
            }
        }
    }
}
