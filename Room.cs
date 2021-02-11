using System;
using System.Collections.Generic;
using System.Text;

namespace Brooklyn99.RoomTypes
{
    public class Room
    {
        public string Name { get; }
        public string Description { get; }
        public List<string> Exits { get; }
        public List<People> NPC { get; }
        public Room(string name, string description, List<string> exits, List<People> npc)
        {
            Name = name;
            Description = description;
            Exits = exits;
            NPC = npc;
        }
    }
    public class People
    {
        public string Name { get; }
        public string Converstation { get; }
        public People(string name, string convo)
        {
            Name = name;
            Converstation = convo;
        }
    }
}
