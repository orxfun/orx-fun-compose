namespace Orx.Fun.Compose;

public static partial class ComposeExtensions
{
    public static Func<A, (A, B)> Cached<A, B>(this Func<A, B> f)
        => a => (a, f(a));
    public static Func<A, B, (A, B, C)> Cached<A, B, C>(this Func<A, B, C> f)
        => (a, b) => (a, b, f(a, b));
    public static Func<A, B, C, (A, B, C, D)> Cached<A, B, C, D>(this Func<A, B, C, D> f)
        => (a, b, c) => (a, b, c, f(a, b, c));
}
