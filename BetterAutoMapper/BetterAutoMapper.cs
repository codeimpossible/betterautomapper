using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BetterAutoMapper
{
    public static class BAM
    {
        public static readonly BetterAutoMapper BOOM = new BetterAutoMapper();
    }

    public class BetterAutoMapper
    {
        public TTo Map<TFrom, TTo>(TFrom from)
        {
            var json = GetJson(from);
            return GetObject<TTo>(json);
        }

        public TTo Map<TFrom, TTo>(TFrom from, Func<TFrom, dynamic> transposeFn)
        {
            var transposed = transposeFn(from);
            IDictionary<string, dynamic> transposedDict = GetDictionary(transposed);
            IDictionary<string, dynamic> sourceDict = GetDictionary(from);
            IDictionary<string, dynamic> merged = Merge(transposedDict, sourceDict);
            var json = GetJson(merged);
            return GetObject<TTo>(json);
        }

        private Dictionary<string, dynamic> GetDictionary<TFrom>(TFrom from)
        {
            var json = GetJson(from);
            return GetObject<Dictionary<string, dynamic>>(json);
        }

        private T GetObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        private string GetJson<T>(T instance)
        {
            return JsonConvert.SerializeObject(instance);
        }

        private IDictionary<TKey, TValue> Merge<TKey, TValue>(IDictionary<TKey, TValue> dictA, IDictionary<TKey, TValue> dictB)
        {
            return dictA.Keys.Union(dictB.Keys).ToDictionary(k => k, k => dictA.ContainsKey(k) ? dictA[k] : dictB[k]);
        }
    }
}
