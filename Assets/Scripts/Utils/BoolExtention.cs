public static class BoolExtention
{
    public static int ToInt(this bool value)
    {
        return value ? 1 : -1;
    }
}
