using System.Collections.Generic;

namespace ME.ECS {

    public static class Worlds {

        public static World currentWorld;
        public static readonly List<IWorldBase> registeredWorlds = new List<IWorldBase>();

        public static IStateBase currentState;
        private static Dictionary<int, World> cache = new Dictionary<int, World>(1);

        internal static bool isInDeInitialization;
        public static void DeInitializeBegin() {

            Worlds.isInDeInitialization = true;

        }

        public static void DeInitializeEnd() {
            
            Worlds.isInDeInitialization = false;
            
        }

        public static World GetWorld(int id) {

            World world;
            if (Worlds.cache.TryGetValue(id, out world) == true) {

                return world;
                
            }

            return null;

        }

        public static void Register(World world) {
            
            Worlds.registeredWorlds.Add(world);
            Worlds.cache.Add(world.id, world);
            
        }
        
        public static void UnRegister(World world) {
            
            if (Worlds.registeredWorlds != null) Worlds.registeredWorlds.Remove(world);
            if (Worlds.cache != null) Worlds.cache.Remove(world.id);
            
        }

    }

}