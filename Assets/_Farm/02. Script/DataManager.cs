using System;
using UnityEngine;

namespace Farm
{
    public class DataManager : SingletonCore<DataManager> //씬이 전환되어도 사라지지 않아야 하기 때문에.
    {
        public int SelectCharacterIndex { get; set;}

        
    }
}