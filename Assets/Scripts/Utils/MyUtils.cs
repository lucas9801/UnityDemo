public class MyUtils
{
    public static bool UnityObjectIsNull(object obj)
    {
        return obj == null || obj.Equals(null);
    }
}