using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;

namespace Common
{
    public abstract class ComboBoxItemTypeConvert : TypeConverter
    {
        public Hashtable _hash = null;

        public ComboBoxItemTypeConvert()
        {
            _hash = new Hashtable();
            GetConvertHash();
        }

        public abstract void GetConvertHash();

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {

            string[] ids = new string[_hash.Values.Count];

            int i = 0;

            List<string> valueList = new List<string>();

            foreach (DictionaryEntry myDE in _hash)
            {
                valueList.Add(myDE.Value.ToString());
            }

            valueList = valueList.OrderBy(p => p).ToList();

            for (int index = 0; index < valueList.Count; index++)
            {
                foreach (DictionaryEntry myDE in _hash)
                {
                    if (myDE.Value.ToString() == valueList[index])
                    {
                        ids[i] = (string)(myDE.Key);
                        i++;
                        break;
                    }
                }
            }
            return new StandardValuesCollection(ids);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object v)
        {
            try
            {
                if (v is string)
                {
                    foreach (DictionaryEntry myDE in _hash)
                    {
                        if (myDE.Value.Equals((v.ToString())))
                            return myDE.Key;
                    }
                }
                return base.ConvertFrom(context, culture, v);
            }
            catch
            {
                return "";
                throw new Exception("a");
            }

        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object v, Type destinationType)
        {
            try
            {
                if (destinationType == typeof(string))
                {
                    foreach (DictionaryEntry myDE in _hash)
                    {
                        if (myDE.Key.Equals(v))
                            return myDE.Value.ToString();
                    }
                    return "";
                }
            }
            catch { }
            return base.ConvertTo(context, culture, v, destinationType);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }
    }
}
