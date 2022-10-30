using System.Collections.Generic;
using GeneralApi.Entities;
using GeneralApi.Contracts;
using System;
using System.Linq;

namespace GeneralApi.Utils
{
    public class TesteoManager
    {
        #region Singleton
        private readonly static TesteoManager _instance;
        public static TesteoManager Current { get { return _instance; } }
        static TesteoManager() { _instance = new TesteoManager(); }
        private TesteoManager()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public string GetX()
        {
            return "get x";
        }
        public void Procesar(string a_procesar)
        {
            //procesar algo
        }
    }
}