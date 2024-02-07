namespace Orx.Fun.Compose;

public static partial class ComposeExtensions
{
    public static Func<Res<B>> Map<A, B>(this Func<Res<A>> f, Func<A, B> g)
        => () => f().Map(g);
    public static Func<A, Res<C>> Map<A, B, C>(this Func<A, Res<B>> f, Func<B, C> g)
        => a => f(a).Map(g);
    public static Func<A, Res<D>> Map<A, B, C, D>(this Func<A, Res<(B, C)>> f, Func<B, C, D> g)
        => a => f(a).Map(x => g(x.Item1, x.Item2));

    public static Func<Res<B>> TryMap<A, B>(this Func<Res<A>> f, Func<A, B> g)
        => () => f().TryMap(g);
    public static Func<A, Res<C>> TryMap<A, B, C>(this Func<A, Res<B>> f, Func<B, C> g)
        => a => f(a).TryMap(g);
    public static Func<A, Res<D>> TryMap<A, B, C, D>(this Func<A, Res<(B, C)>> f, Func<B, C, D> g)
        => a => f(a).TryMap(x => g(x.Item1, x.Item2));

    public static Func<Res<B>> FlatMap<A, B>(this Func<Res<A>> f, Func<A, Res<B>> g)
        => () => f().FlatMap(g);
    public static Func<A, Res<C>> FlatMap<A, B, C>(this Func<A, Res<B>> f, Func<B, Res<C>> g)
        => a => f(a).FlatMap(g);
    public static Func<A, Res<D>> FlatMap<A, B, C, D>(this Func<A, Res<(B, C)>> f, Func<B, C, Res<D>> g)
        => a => f(a).FlatMap(x => g(x.Item1, x.Item2));

    public static Func<A, Res<A>> OkIf<A>(this Func<A, bool> validationCriterion)
        => a => Ok(a).OkIf(validationCriterion);
    public static Func<A, Res<A>> OkIf<A>(this Func<A, Res<A>> f, Func<A, bool> validationCriterion)
        => a => f(a).OkIf(validationCriterion);
}
