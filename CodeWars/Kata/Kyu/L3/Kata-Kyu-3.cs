using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

using Res = CodeWars.Properties.Resources;

namespace CodeWars {
    public static partial class KataBase {
        /// <summary>Интерактивное создание класса</summary>
        /// <param name="className">Имя класса</param>
        /// <param name="properties">Свойства класса (имя, тип).</param>
        /// <param name="actualType"></param>
        /// <returns>false, если класс уже существует в этой сборке</returns>
        [KataType(LevelTypes.Kyu, 3, "589394ae1a880832e2000092")]
        public static bool DefineClass(string className, Dictionary<string, Type> properties, ref Type actualType) {
            if (string.IsNullOrEmpty(className)) {
                throw new ArgumentException(Res.IsNullOrEmpty, nameof(className));
            }

            if (properties is null) {
                throw new ArgumentNullException(nameof(properties));
            }

            if (actualType is null) {
                throw new ArgumentNullException(nameof(actualType));
            }

            TypeBuilder tb = GetTypeBuilder(className);
            var gType = Assembly.GetExecutingAssembly().GetType(className);
            if (gType != null) {
                return false;
            }
            foreach (KeyValuePair<string, Type> member in properties) {
                _ = tb.DefineProperty(member.Key, PropertyAttributes.HasDefault, member.Value, null);
            }
            actualType = tb.CreateType();
            return true;
        }

        private static TypeBuilder GetTypeBuilder(string typeName) {
            AssemblyName an = Assembly.GetExecutingAssembly().GetName();
            //Создание динамической сборки для динамического класса
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(typeName);
            return moduleBuilder.DefineType(typeName,
              TypeAttributes.Public |
              TypeAttributes.Class |
              TypeAttributes.AutoClass |
              TypeAttributes.AnsiClass |
              TypeAttributes.BeforeFieldInit |
              TypeAttributes.AutoLayout,
              null);
        }
    }
}

