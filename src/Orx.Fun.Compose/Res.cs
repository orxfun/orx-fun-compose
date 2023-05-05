namespace Orx.Fun.Compose;

public static partial class ComposeExtensions
{
    public static Func<Res> OkIf(this Func<bool> validationCriterion)
        => () => ResultExtensions.OkIf(validationCriterion());
    public static Func<Res> OkIf(this Func<Res> f, Func<bool> validationCriterion)
        => () => f().OkIf(validationCriterion);

    public static Func<Res> Do(this Func<Res> f, Action g)
        => () => f().Do(g);

    public static Func<Res> FlatMap(this Func<Res> f, Func<Res> g)
        => () => f().FlatMap(g);
}
