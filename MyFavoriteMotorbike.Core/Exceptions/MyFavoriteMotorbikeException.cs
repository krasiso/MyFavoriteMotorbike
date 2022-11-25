namespace MyFavoriteMotorbike.Core.Exceptions
{
    public class MyFavoriteMotorbikeException : ApplicationException
    {
        public MyFavoriteMotorbikeException()
        {

        }

        public MyFavoriteMotorbikeException(string errorMessage)
            : base(errorMessage)
        {

        }
    }
}
