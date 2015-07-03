using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterAutoMapper
{
    public static class BAM
    {
        public static readonly BetterAutoMapper BOOM = new BetterAutoMapper();
    }

    public class BetterAutoMapper
    {
        public TTo Map<TFrom, TTo>(TFrom from, bool strict = false)
        {
            var json = GetJson(from);
            var obj = GetObject<TTo>(json);

            if (strict)
            {
                ValidateStrict(from, obj);
            }

            return obj;
        }

        public TTo Map<TFrom, TTo>(TFrom from, Func<TFrom, dynamic> transposeFn, bool strict = false)
        {
            var transposed = transposeFn(from);
            IDictionary<string, dynamic> transposedDict = GetDictionary(transposed);
            IDictionary<string, dynamic> sourceDict = GetDictionary(from);
            IDictionary<string, dynamic> merged = Merge(transposedDict, sourceDict);
            var json = GetJson(merged);
            var obj = GetObject<TTo>(json);

            if (strict)
            {
                ValidateStrict(from, obj);
            }

            return obj;
        }

        private void ValidateStrict<TFrom, TTo>(TFrom from, TTo to)
        {
            IDictionary<string, dynamic> fromDict = GetDictionary(from);
            IDictionary<string, dynamic> toDict = GetDictionary(to);

            var diff = fromDict.Except(toDict);
            if (diff.Count() > 0)
            {
                throw new BAMStrictMapViolationException(typeof(TFrom), typeof(TTo), diff.Select(p => p.Key));
            }
        }

        private Dictionary<string, dynamic> GetDictionary<TFrom>(TFrom from)
        {
            var json = GetJson(from);
            return GetObject<Dictionary<string, dynamic>>(json);
        }

        private Dictionary<string, dynamic> GetDictionary(string json)
        {
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
