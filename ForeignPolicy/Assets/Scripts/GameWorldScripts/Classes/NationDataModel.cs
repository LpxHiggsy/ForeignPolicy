using System;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts.GameWorldScripts.Classes
{
    [System.Serializable]
    public class NationDataModel
    {
        public string Name;
        public int Budget;
        public int Population;
		public Vector3 MapPosition;
        public List<string> TradingPartners;
        public List<string> Allies;
        public List<string> Enemies;

        public NationDataModel()
        {
            Name = String.Empty;
            Budget = 0;
            Population = 0;
			MapPosition = new Vector3 (0.0f, 0.0f, 0.0f);
            TradingPartners = new List<string>();
            Allies = new List<string>();
            Enemies = new List<string>();
        }
    }
}
