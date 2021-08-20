namespace Pluto.Rover.Api.Constants
{
    public static class CardinalPointConstants
    {
        public const char West = 'W';
        public const char North = 'N';
        public const char East = 'E';
        public const char South = 'S';
    }

    public static class RotationConstants
    {
        public const char Left = 'L';
        public const char Right = 'R';
    }

    public static class MovingConstants
    {
        public const char Forward = 'F';
        public const char Backward = 'B';
    }

    public static class ErrorMessages
    {
        public const string InvalidInput = "Input is not valid. Only accepted moves are: 'F', 'B', 'L', 'R'";
    }
}