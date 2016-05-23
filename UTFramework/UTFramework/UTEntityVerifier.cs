using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.API.MVCUTFramework
{
    internal class UTEntityVerifier : IEntityVerifier
    {
        public UTEntityVerifier(IValueProvider provider)
        {
            valueProvider = provider;
        }

        private IValueProvider valueProvider { get; set; }

        public void Verify(object target, params Type[] typesToVerify)
        {
            foreach (var property in target.GetType().GetProperties())
            {
                var type = property.PropertyType;
                var value = valueProvider[type];
                if (value != null)
                {
                    VerifyValue(type, property.GetValue(value), value);
                }
                else
                {
                    if (typesToVerify.Contains(type))
                    {
                        Verify(property.GetValue(value), typesToVerify);
                    }
                }
            }
        }

        private void VerifyValue(Type type, object source, object dest)
        {
            bool equals;
            if (type == typeof(string))
            {
                equals = string.Equals((string)source, (string)dest, StringComparison.OrdinalIgnoreCase);
            }
            else if (type == typeof(int))
            {
                equals = (int)source == (int)dest;
            }
            else if (type == typeof(bool))
            {
                equals = (bool)source == (bool)dest;
            }
            else if (type == typeof(char))
            {
                equals = (char)source == (char)dest;
            }
            else if (type == typeof(byte))
            {
                equals = (byte)source == (byte)dest;
            }
            else if (type == typeof(double))
            {
                equals = (double)source == (double)dest;
            }
            else if (type == typeof(DateTime))
            {
                equals = (DateTime)source == (DateTime)dest;
            }
            else
            {
                throw new Exception(string.Format("Verify failed, type {0}, source value {1}, source value {2}", type, source, dest));
            }
        }
    }
}
