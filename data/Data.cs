﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DapanzSceneTools
{
    public class Data
    {

    }


    public class Data<T> : Data
    {
        public T value;

        public Data(T value)
        {
            this.value = value;
        }
    }


    public class Data<T0, T1> : Data
    {
        public T0 value0;
        public T1 value1;

        public Data(T0 value0, T1 value1)
        {
            this.value0 = value0;
            this.value1 = value1;
        }
    }


    public class Data<T0, T1, T2> : Data
    {
        public T0 value0;
        public T1 value1;
        public T2 value2;

        public Data(T0 value0, T1 value1, T2 value2)
        {
            this.value0 = value0;
            this.value1 = value1;
            this.value2 = value2;
        }
    }


    public class Data<T0, T1, T2, T3> : Data
    {
        public T0 value0;
        public T1 value1;
        public T2 value2;
        public T3 value3;

        public Data(T0 value0, T1 value1, T2 value2, T3 value3)
        {
            this.value0 = value0;
            this.value1 = value1;
            this.value2 = value2;
            this.value3 = value3;
        }
    }


    public class Data<T0, T1, T2, T3, T4> : Data
    {
        public T0 value0;
        public T1 value1;
        public T2 value2;
        public T3 value3;
        public T4 value4;

        public Data(T0 value0, T1 value1, T2 value2, T3 value3, T4 value4)
        {
            this.value0 = value0;
            this.value1 = value1;
            this.value2 = value2;
            this.value3 = value3;
            this.value4 = value4;
        }
    }

    public class Data<T0, T1, T2, T3, T4,T5> : Data
    {
        public T0 value0;
        public T1 value1;
        public T2 value2;
        public T3 value3;
        public T4 value4;
        public T5 value5;

        public Data(T0 value0, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            this.value0 = value0;
            this.value1 = value1;
            this.value2 = value2;
            this.value3 = value3;
            this.value4 = value4;
            this.value5 = value5;
        }
    }
}