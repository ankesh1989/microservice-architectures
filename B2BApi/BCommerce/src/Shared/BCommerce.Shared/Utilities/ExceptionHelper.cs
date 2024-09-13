namespace BCommerce.Shared.Utilities
{
    public static class ExceptionHelper
    {
        public static void ThrowCustomException(string message) 
        {
            throw new ApplicationException($"Error in {message} endpoint");
        }

        public static void ThrowExceptionMessage(string message)
        {
            throw new ApplicationException($"{message}");
        }
    }
}