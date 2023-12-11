using ConsoleApp1.Assets.Encounters;
using ConsoleApp1.Assets.Enemies;
using ConsoleApp1.Assets.Models;
using System;
using System.Reflection;
using System.Text;

namespace ConsoleApp1.Assets.Rooms
{
    public static class RoomEngine
    {
        public static void GenerateNextArea(ConsoleApp1.Assets.Player.Player player)
        {
            Random r = new Random();
            int roomVal = r.Next(1, 5);
            GenerateRoom(player, (RoomOrHallTypes)roomVal);
        }

        private static void GenerateRoom(Player.Player player, RoomOrHallTypes room)
        {
            Console.Clear();
            Console.WriteLine(AsciiArt.GetRoomAscii(room, player));
            Typewriter.Write($"You walk into a {room.GetRoomDescription()}");

            EncounterEngine.GenerateEncounter(player);

            if (!player.Died)
            {
                if (player.HasSpecialEncounterPending())
                {
                    EncounterEngine.GenerateSpecialItem(player);
                }
                else
                {
                    EncounterEngine.GenerateItem(player);
                }
                Console.Clear();
                Console.WriteLine(AsciiArt.GetRoomAscii(room, player));
                Typewriter.Write($"You are standing in a {room.GetRoomDescription()}");
                AwaitUserInput(room);
                GenerateNextArea(player);
            }
        }

        private static void AwaitUserInput(RoomOrHallTypes type)
        {
            string directionOptions = type.GetTypeOfRoomOrHall() == RoomOrHall.Room
                ? "[D]oor"
                : type == RoomOrHallTypes.HallDeadend
                    ? "[L]eft or [R]ight"
                    : "[L]eft, [R]ight, or [S]traight";

            Typewriter.Write($"You can go through the {directionOptions}.");

            var input = Console.ReadLine()?.ToLower() ?? "";

            if (type.GetTypeOfRoomOrHall() == RoomOrHall.Room)
            {
                if (input == "d")
                    Typewriter.Write("You go through the door.");
                else
                {
                    AwaitUserInput(type);
                }
            }
            else
            {
                if (input == "l")
                    Typewriter.Write("You go through the left door.");
                else if (input == "r")
                    Typewriter.Write("You go through the right door.");
                else if (type == RoomOrHallTypes.HallTwoDoors && input == "s")
                    Typewriter.Write("You go straight.");
                else
                    AwaitUserInput(type);
            }
        }
    }

    public enum RoomOrHallTypes
    {
        [RoomDescription("Room", RoomOrHall.Room, "")]
        Room,

        [RoomDescription("Dead-end Hallway", RoomOrHall.Hall, "")]
        HallDeadend,

        [RoomDescription("Hallway", RoomOrHall.Hall, "")]
        HallTwoDoors,

        [RoomDescription("Room", RoomOrHall.Room, "")]
        Room2,

        [RoomDescription("Room", RoomOrHall.Room, "")]
        Room3
    }

    public enum RoomOrHall
    {
        Room,
        Hall
    }

    [AttributeUsage(AttributeTargets.Field, Inherited =false, AllowMultiple =false)]
    sealed class RoomDescriptionAttribute : Attribute
    {
        public string Description { get; set; }
        public RoomOrHall RoomOrHall { get; set; }
        public string NudgeText { get; set; }

        public RoomDescriptionAttribute(string description, RoomOrHall roomOrHall, string nudgeText = null)
        {
            Description = description;
            RoomOrHall = roomOrHall;
            NudgeText = nudgeText;
        }
    }

    public static class RoomOrHallTypesExtensions
    {
        public static string GetRoomDescription(this RoomOrHallTypes room)
        {
            FieldInfo fieldInfo = room.GetType().GetField(room.ToString());
            RoomDescriptionAttribute attribute = (RoomDescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(RoomDescriptionAttribute));

            return attribute?.Description ?? "Room";
        }

        public static RoomOrHall GetTypeOfRoomOrHall(this RoomOrHallTypes room)
        {
            FieldInfo fieldInfo = room.GetType().GetField(room.ToString());
            RoomDescriptionAttribute attribute = (RoomDescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(RoomDescriptionAttribute));

            return attribute.RoomOrHall;
        }
    }
}