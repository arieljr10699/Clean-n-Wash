using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public static class Static
    {

    private static bool level1;
    private static bool level2;

    public static bool Level1
        {
            get
            {
                return level1;
            }
            set
            {
                level1 = value;
            }
        }

        public static bool Level2
        {
            get
            {
            return level2 ;
            }
            set
            {
                level2 = value;
            }
        }
    }


