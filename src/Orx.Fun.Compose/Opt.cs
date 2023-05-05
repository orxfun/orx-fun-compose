namespace Orx.Fun.Compose;

public static partial class ComposeExtensions
{
    public static Func<A, Opt<C>> Map<A, B, C>(this Func<A, Opt<B>> f, Func<B, C> g)
        => a => f(a).Map(g);
    public static Func<A, Opt<D>> Map<A, B, C, D>(this Func<A, Opt<(B, C)>> f, Func<B, C, D> g)
        => a => f(a).Map(x => g(x.Item1, x.Item2));

    public static Func<A, Opt<C>> FlatMap<A, B, C>(this Func<A, Opt<B>> f, Func<B, Opt<C>> g)
        => a => f(a).FlatMap(g);
    public static Func<A, Opt<D>> FlatMap<A, B, C, D>(this Func<A, Opt<(B, C)>> f, Func<B, C, Opt<D>> g)
        => a => f(a).FlatMap(x => g(x.Item1, x.Item2));

    public static Func<A, Opt<A>> SomeIf<A>(this Func<A> f, Func<A, bool> validationCriterion)
        => a => OptionExtensions.SomeIf(validationCriterion(a), a);
    public static Func<A, Opt<B>> SomeIf<A, B>(this Func<A, B> f, Func<B, bool> validationCriterion)
    {
        return a =>
        {
            var b = f(a);
            return OptionExtensions.SomeIf(validationCriterion(b), b);
        };
    }
    public static Func<A, Opt<(B, C)>> SomeIf<A, B, C>(this Func<A, (B, C)> f, Func<B, C, bool> validationCriterion)
    {
        return a =>
        {
            var bc = f(a);
            return OptionExtensions.SomeIf(validationCriterion(bc.Item1, bc.Item2), bc);
        };
    }
    public static Func<A, Opt<B>> SomeIf<A, B>(this Func<A, Opt<B>> f, Func<B, bool> validationCriterion)
    {
        return a =>
        {
            var b = f(a);
            return b.SomeIf(b => validationCriterion(b));
        };
    }
    public static Func<A, Opt<(B, C)>> SomeIf<A, B, C>(this Func<A, Opt<(B, C)>> f, Func<B, C, bool> validationCriterion)
    {
        return a =>
        {
            var bc = f(a);
            return bc.SomeIf(bc => validationCriterion(bc.Item1, bc.Item2));
        };
    }
}
