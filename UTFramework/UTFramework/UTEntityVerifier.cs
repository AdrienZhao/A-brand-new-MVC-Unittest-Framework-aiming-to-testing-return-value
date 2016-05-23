using System;
using System.Collections;
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
                    VerifyValue(type, property.GetValue(target), value);
                }
                else
                {
                    if (type.IsGenericType)
                    {
                        var args = type.GetGenericArguments();
                        type = args[0];
                        var propertyValue = (IList)property.GetValue(target);
                        if(propertyValue.Count != 2)
                        {
                            throw new Exception("Verify failed.");
                        }
                        if (typesToVerify.Contains(type))
                        {
                            foreach (var subTarget in propertyValue)
                            {
                                Verify(subTarget, typesToVerify);
                            }
                        }
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
                throw new Exception(string.Format("Verify failed, type not supported, type {0}, source value {1}, source value {2}", type, source, dest));
            }

            if (!equals)
            {
                throw new Exception(string.Format("Verify failed, type {0}, source value {1}, source value {2}", type, source, dest));
            }
        }
    }
}
