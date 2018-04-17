using System;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.GameWorldScripts.Classes
{
	public abstract class FPMapper
	{
        private static Dictionary<string, Sprite> Sprites = new Dictionary<string, Sprite>();

        public static void Initialise()
        {
            Sprites.Clear();

            Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/The World");
            foreach(Sprite sprite in sprites)
            {
                Sprites[sprite.name] = sprite;
            }
        }

		public static void MapCountry(GameObject country, NationDataModel ndm)
		{            
			country.name = ndm.Name;

			CountryStanding c = country.AddComponent<CountryStanding>();
			c.Name = ndm.Name;
			c.Population = ndm.Population;
			c.Budget = ndm.Budget;
			c.TradingPartners = ndm.TradingPartners;
			c.Allies = ndm.Allies;
			c.Enemies = ndm.Enemies;
			c.MapPosition = ndm.MapPosition;

			Transform t = country.GetComponent<Transform> ();
			t.position = c.MapPosition;
            t.localScale = new Vector3(0.225f, 0.225f, 0.25f);
                       
			string spritePath = @"Sprites\" + ndm.Name;

            try
            {
                country.AddComponent<SpriteRenderer>().sprite = Sprites[c.Name];
            }
            catch(Exception ex)
            {
                Debug.LogException(ex);
            }

			if (country.GetComponent<SpriteRenderer> ().sprite == null) 
			{
				Debug.LogError (ndm.Name + @"'s Sprite Failed!");
			}

            country.GetComponent<SpriteRenderer>().color =  new Color(21, 236, 58);

            country.AddComponent<PolygonCollider2D> ();
			country.AddComponent <Selectable>();
		}
	}
}

