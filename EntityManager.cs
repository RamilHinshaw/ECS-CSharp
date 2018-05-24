using System;
using System.Collections.Generic;

namespace RamilH.ECS
{
	public static class EntityManager
	{
		public static List<Entity> Entities = new List<Entity>();

		public static void Start() 
		{ 
			//Go through each Entity Component and Invoke the Start Method

			// e = entity	|	c = component
			for (int e = 0; e < Entities.Count; e++)
			{
				Entity entity = Entities[e];

				for (int c = 0; c < entity.components.Count; c++)
					entity.components[c].Start();

			}
		}

		public static void Update()
		{
			//Go through each Entity Component and Invoke the Update Method

			// e = entity	|	c = component
			for (int e = 0; e < Entities.Count; e++)
			{
				Entity entity = Entities[e];

				for (int c = 0; c < entity.components.Count; c++)
				{
					entity.components[c].Update();
					//Action action = entity.components[c].Update;
				}

			}
		}

		public static void Dispose() { }



		private static void InvokeComponentMethod(Action method)
		{
			//Invoke this passed method
			method.Invoke();
		}
	}
}
