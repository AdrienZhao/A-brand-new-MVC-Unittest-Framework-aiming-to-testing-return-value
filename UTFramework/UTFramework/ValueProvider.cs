using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.API.MVCUTFramework
{
    public class ValueProvider : IValueProvider
    {
        IDictionary<Type, object> typeValues;

        public ValueProvider()
        {
            typeValues = new Dictionary<Type, object>();

            //TODO: controlled by configuration files
            typeValues.Add(typeof(string), "APITestingValue");
            typeValues.Add(typeof(bool), true);
            typeValues.Add(typeof(char), 'W');
            typeValues.Add(typeof(byte), 50);
            typeValues.Add(typeof(int), 100);
            typeValues.Add(typeof(double), 100.00);
            typeValues.Add(typeof(DateTime), new DateTime(1989, 5, 18));
        }

        public object this[Type type]
        {
            get
            {
                if (typeValues.ContainsKey(type))
                {
                    return typeValues[type];
                }
                return null;
            }

            set
            {
                typeValues[type] = value;
            }
        }

        public IEnumerator<KeyValuePair<Type, object>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
