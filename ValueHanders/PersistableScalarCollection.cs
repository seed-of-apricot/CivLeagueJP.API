using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CivLeagueJP.API.ValueHandlers
{
    /// <summary>
    /// List for EF.
    /// Referenced from stackoverflow.com.
    /// Referred: https://stackoverflow.com/questions/11985267
    /// Author: Bernhard Kircher(https://stackoverflow.com/users/128695)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PersistableScalarCollection<T> : ICollection<T>
    {
        const string DefaultValueSeperator = "|";
        readonly string[] DefaultValueSeperators = new string[] { DefaultValueSeperator };

        private List<T> Data { get; set; }

        public PersistableScalarCollection()
        {
            Data = new List<T>();
        }

        protected abstract T ConvertSingleValueToRuntime(string rawValue);
        protected abstract string ConvertSingleValueToPersistable(T value);

        protected virtual string ValueSeperator
        {
            get
            {
                return DefaultValueSeperator;
            }
        }

        protected virtual string[] ValueSeperators
        {
            get
            {
                return DefaultValueSeperators;
            }
        }

        public string SerializedValue
        {
            get
            {
                var serializedValue = string.Join(ValueSeperator.ToString(),
                    Data.Select(x => ConvertSingleValueToPersistable(x))
                    .ToArray());
                return serializedValue;
            }
            set
            {
                Data.Clear();

                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

                Data = new List<T>(value.Split(ValueSeperators, StringSplitOptions.None)
                    .Select(x => ConvertSingleValueToRuntime(x)));
            }
        }

        #region ICollection<T> Members

        public void Add(T item)
        {
            Data.Add(item);
        }

        public void Clear()
        {
            Data.Clear();
        }

        public bool Contains(T item)
        {
            return Data.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Data.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return Data.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            return Data.Remove(item);
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        #endregion
    }

    [ComplexType]
    public class EFStringList : PersistableScalarCollection<string>
    {
        protected override string ConvertSingleValueToRuntime(string rawValue)
        {
            return rawValue;
        }

        protected override string ConvertSingleValueToPersistable(string value)
        {
            return value.ToString();
        }
    }

    [ComplexType]
    public class EFIntList : PersistableScalarCollection<int>
    {
        protected override int ConvertSingleValueToRuntime(string rawValue)
        {
            return int.Parse(rawValue);
        }

        protected override string ConvertSingleValueToPersistable(int value)
        {
            return value.ToString();
        }
    }

    [ComplexType]
    public class EFDoubleList : PersistableScalarCollection<double>
    {
        protected override double ConvertSingleValueToRuntime(string rawValue)
        {
            return double.Parse(rawValue);
        }

        protected override string ConvertSingleValueToPersistable(double value)
        {
            return value.ToString();
        }
    }

    [ComplexType]
    public class EFIntArrayList : PersistableScalarCollection<int[]>
    {
        protected override int[] ConvertSingleValueToRuntime(string rawValue)
        {
            return rawValue.Split(',').Select(t => Convert.ToInt32(t)).ToArray();
        }

        protected override string ConvertSingleValueToPersistable(int[] value)
        {
            return string.Join(",", value);
        }
    }

    [ComplexType]
    public class EFDatetimeList : PersistableScalarCollection<DateTime>
    {
        protected override DateTime ConvertSingleValueToRuntime(string rawValue)
        {
            return DateTime.Parse(rawValue);
        }

        protected override string ConvertSingleValueToPersistable(DateTime value)
        {
            return value.ToString();
        }
    }

    [ComplexType]
    public class EFDatetimeArrayList : PersistableScalarCollection<DateTime[]>
    {
        protected override DateTime[] ConvertSingleValueToRuntime(string rawValue)
        {
            return rawValue.Split(',').Select(t => DateTime.Parse(t)).ToArray();
        }

        protected override string ConvertSingleValueToPersistable(DateTime[] value)
        {
            return string.Join(",", value.Select(t => t.ToString()).ToArray());
        }
    }
}