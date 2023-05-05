namespace Orx.Fun.Compose;

public static partial class ComposeExtensions
{
    public static Func<A, C> Map<A, B, C>(this Func<A, B> f, Func<B, C> g)
        => a => g(f(a));
    public static Func<A, D> Map<A, B, C, D>(this Func<A, (B, C)> f, Func<B, C, D> g)
    {
        return a =>
        {
            var bc = f(a);
            return g(bc.Item1, bc.Item2);
        };
    }
}
