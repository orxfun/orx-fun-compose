namespace Orx.Fun.Compose;

public static partial class ComposeExtensions
{
    public static Func<A, Func<B>> Curry<A, B>(this Func<A, B> f)
        => a => () => f(a);
    public static Func<A, Func<B, C>> Curry<A, B, C>(this Func<A, B, C> f)
        => a => b => f(a, b);


    public static Func<B> Partial<A, B>(this Func<A, B> f, A a)
        => () => f(a);
    public static Func<B, C> Partial<A, B, C>(this Func<A, B, C> f, A a)
        => b => f(a, b);
    public static Func<B, C, D> Partial<A, B, C, D>(this Func<A, B, C, D> f, A a)
        => (b, c) => f(a, b, c);
    public static Func<B, C, D, E> Partial<A, B, C, D, E>(this Func<A, B, C, D, E> f, A a)
        => (b, c, d) => f(a, b, c, d);



    //static Func<A, C> Compose<A, B, C>(Func<A, B> f, Func<B, C> g)
    //    => a => g(f(a));


}
