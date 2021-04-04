namespace BattleCalculatorDemo.AbstractionLayer.Utils
{
    public interface IDeepCloneable
    {
    }

    public static class NomadPattern
    {
        public static string ToJson<T>(this T obj) => Newtonsoft.Json.JsonConvert.SerializeObject(obj);
    }
}