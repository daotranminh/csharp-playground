using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;

namespace HelloWebApi.Models
{
    public class ShiftTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                var parts = ((string)value).Split('T');

                DateTime date;
                if (DateTime.TryParse((string)parts[0], out date))
                {
                    return new Shift()
                    {
                        Date = date,
                        Start = parts[1].ToTimeSpan(),
                        End = parts[2].ToTimeSpan()
                    };
                }
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}