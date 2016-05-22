using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.API.MVCUTFramework
{
    internal class UTEntityInitializer : IEntityInitializer
    {
        public UTEntityInitializer(IValueProvider valueProvider)
        {
            ValueProvider = valueProvider;
        }

        IValueProvider ValueProvider { get; set; }

        public T Initialize<T>(params Type[] propertieTypes)
        {
            var properties = typeof(T).GetProperties();
            return (T)Initialize(typeof(T), properties, propertieTypes);
        }

        private object Initialize(Type targetType, System.Reflection.PropertyInfo[] properties, Type[] propertieTypes)
        {
            var targetObject = Activator.CreateInstance(targetType);
            foreach (var property in properties)
            {
                var value = ValueProvider[property.PropertyType];
                if (ValueProvider[property.PropertyType] != null)
                {
                    property.SetValue(targetObject, value);
                }
                else
                {
                    if (property.PropertyType.IsGenericType)
                    {
                        var genericTypes = property.PropertyType.GetGenericArguments();
                        if (genericTypes.Count() > 1)
                        {
                            throw new NotSupportedException();
                        }
                        var type = genericTypes[0];
                        property.SetValue(targetObject, GetGenericTypeValue(type, propertieTypes));
                    }
                    else
                    {
                        throw new Exception("Something not haddled");
                    }
                }
            }
            return targetObject;
        }

        private IList GetGenericTypeValue(Type type, Type[] propertieTypes)
        {
            var list = (IList)typeof(List<>).MakeGenericType(type).GetConstructor(Type.EmptyTypes).Invoke(null);
            for (int i = 0; i < 2; i++)
            {
                var value = Initialize(type, type.GetProperties(), propertieTypes);
                list.Add(value);
            }
            return list;
        }
    }
}